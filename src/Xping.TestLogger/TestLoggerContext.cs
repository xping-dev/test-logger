/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Xping.TestLogger.Configurations;
using Xping.TestLogger.Core;
using Xping.TestLogger.Services;

namespace Xping.TestLogger;

/// <summary>
/// 
/// </summary>
/// <param name="sessionBuilder"></param>
/// <param name="sessionUploader"></param>
/// <param name="options"></param>
public class TestLoggerContext(
    ITestSessionBuilder sessionBuilder,
    ITestSessionUploader sessionUploader,
    IOptions<TestLoggerOptions> options)
{
    private readonly ITestSessionBuilder _sessionBuilder = sessionBuilder;
    private readonly ITestSessionUploader _sessionUploader = sessionUploader;
    private readonly IOptions<TestLoggerOptions> _options = options;

    /// <summary>
    /// Handles the event when tests are discovered.
    /// </summary>
    /// <param name="args">The event arguments containing the discovered tests.</param>
    public static void HandleDiscoveredTests(DiscoveredTestsEventArgs args)
    { }

    /// <summary>
    /// Handles the event when a discovery message is received.
    /// </summary>
    /// <param name="args">The event arguments containing the discovery message.</param>
    public static void HandleDiscoveryMessage(TestRunMessageEventArgs args)
    { }

    /// <summary>
    /// Handles the event when discovery is complete.
    /// </summary>
    /// <param name="args">The event arguments containing the discovery completion details.</param>
    public static void HandleDiscoveryComplete(DiscoveryCompleteEventArgs args)
    { }

    /// <summary>
    /// Handles the event when a test run starts.
    /// </summary>
    /// <param name="args">The event arguments containing the test run criteria.</param>
    public static void HandleTestRunStart(TestRunStartEventArgs args)
    { }

    /// <summary>
    /// Handles the event when a test result is received.
    /// </summary>
    /// <param name="args">The event arguments containing the test result.</param>
    public void HandleTestResult(TestResultEventArgs args)
    {
        _sessionBuilder.WithTestResult(args.Result);
    }

    /// <summary>
    /// Handles the event when a test run message is received.
    /// </summary>
    /// <param name="args">The event arguments containing the test run message.</param>
    public static void HandleTestRunMessage(TestRunMessageEventArgs args)
    { }

    /// <summary>
    /// Handles the event when a test run is completed.
    /// </summary>
    /// <param name="args">The event arguments containing the test run completion details.</param>
    public void HandleTestRunComplete(TestRunCompleteEventArgs args)
    {
        TestSession session = _sessionBuilder.Build();

        HttpStatusCode httpStatus = _sessionUploader.Upload(session);

        if (httpStatus == HttpStatusCode.OK)
        {
            Console.Write($"[Xping.io] Test session uploaded successfully.");
        }
        else
        {
            Console.Write($"[Xping.io] Test session upload failed, status: {httpStatus}");
        }
    }

    /// <summary>
    /// Reset the session builder to its initial state.
    /// </summary>
    public void Reset()
    {
        _sessionBuilder.Reset();

        // Set the upload token, version, and start date after resetting the session builder.
        _sessionBuilder
            .WithUploadToken(_options.Value.UploadToken)
            .WithVersion(_options.Value.Version)
            .WithStartDate(DateTime.Now);
    }
}
