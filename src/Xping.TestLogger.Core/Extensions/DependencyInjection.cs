/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Microsoft.Extensions.DependencyInjection;
using Xping.TestLogger.Core.Services;
using Xping.TestLogger.Core.Services.Internals;

namespace Xping.TestLogger.Core.Extensions;

/// <summary>
/// Provides extension methods for adding logger core services to the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the logger core services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddLoggerCore(this IServiceCollection services)
    {
        services.AddTransient<ITestSessionSerializer, TestSessionSerializer>();
        return services;
    }
}
