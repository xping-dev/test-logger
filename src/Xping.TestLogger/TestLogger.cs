/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

using Xping.TestLogger.Configurations.Internals;
using Xping.TestLogger.Converters.Extensions;
using Xping.TestLogger.Core.Extensions;
using Xping.TestLogger.Services;
using Xping.TestLogger.Services.Internals;

namespace Xping.TestLogger;

/// <summary>
/// The TestLogger class is responsible for logging test events during the execution of tests.
/// </summary>
[FriendlyName("xping")]
[ExtensionUri("logger://xping/v1")]
public class TestLogger : ITestLoggerWithParameters
{
    private Lazy<IHost> _host = null!;

    /// <summary>
    /// Gets the current test logger context.
    /// </summary>
    public TestLoggerContext? Context { get; private set; }

    /// <summary>
    /// Initializes the test logger with the specified events and parameters.
    /// </summary>
    /// <param name="events">The test logger events to subscribe to.</param>
    /// <param name="parameters">The parameters for the test logger context.</param>
    void ITestLoggerWithParameters.Initialize(TestLoggerEvents events, Dictionary<string, string?> parameters)
    {
        _host = new Lazy<IHost>(valueFactory: () => CreateHost(new TestLoggerParameters(parameters)));

        InitializeContext(events);
    }

    /// <summary>
    /// Initializes the test logger with the specified events and parameters.
    /// </summary>
    /// <param name="events">The test logger events to subscribe to.</param>
    /// <param name="testRunDirectory">The test run directory.</param>
    void ITestLogger.Initialize(TestLoggerEvents events, string testRunDirectory)
    {
        _host = new Lazy<IHost>(valueFactory: () => CreateHost(new TestLoggerParameters(testRunDirectory)));

        InitializeContext(events);
    }

    /// <summary>
    /// Initializes the test logger context and subscribes to the test events.
    /// </summary>
    /// <param name="events">The test logger events to subscribe to.</param>
    private void InitializeContext(TestLoggerEvents events)
    {
        Context = _host.Value.Services.GetRequiredService<TestLoggerContext>();

        // TestLoggerContext is responsible for maintaining the state of the tests execution.
        //events.DiscoveryStart += (_, _) => Context.Reset();
        //events.DiscoveredTests += (_, args) => Context.HandleDiscoveredTests(args);
        //events.DiscoveryMessage += (_, args) => Context.HandleDiscoveryMessage(args);
        //events.DiscoveryComplete += (_, args) => Context.HandleDiscoveryComplete(args);
        //events.TestRunStart += (_, args) => Context.HandleTestRunStart(args);
        events.TestRunStart += (_, args) => Context.Reset();
        events.TestResult += (_, args) => Context.HandleTestResult(args);
        //events.TestRunMessage += (_, args) => Context.HandleTestRunMessage(args);
        events.TestRunComplete += (_, args) => Context.HandleTestRunComplete(args);
    }

    /// <summary>
    /// Creates and configures the host for dependency injection.
    /// </summary>
    /// <returns>The configured host.</returns>
    private static IHost CreateHost(TestLoggerParameters parameters)
    {
        var builder = Host.CreateDefaultBuilder();
        var host = ConfigureHost(builder, parameters).Build();

        return host;
    }

    /// <summary>
    /// Configures the host builder with the required services.
    /// </summary>
    /// <param name="builder">The host builder to configure.</param>
    /// <param name="parameters"></param>
    /// <returns>The configured host builder.</returns>
    private static IHostBuilder ConfigureHost(IHostBuilder builder, TestLoggerParameters parameters)
    {
        builder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
            logging.AddFilter(typeof(HttpClient).FullName, LogLevel.Warning);
        });

        builder.ConfigureServices((_, services) =>
        {
            services.AddLoggerCore();
            services.AddConverters();
            services.AddSingleton(parameters);
            services.ConfigureOptions<TestLoggerOptionsSetup>();
            services.AddHttpClient(TestSessionUploader.HttpClientName);
            services.AddTransient<ITestSessionUploader, TestSessionUploader>();
            services.AddTransient<ITestSessionBuilder, TestSessionBuilder>();
            services.AddSingleton<TestLoggerContext>();
        });

        return builder;
    }
}
