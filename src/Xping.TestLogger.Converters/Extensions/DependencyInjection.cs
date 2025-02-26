/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Microsoft.Extensions.DependencyInjection;

namespace Xping.TestLogger.Converters.Extensions;

/// <summary>
/// Provides extension methods for registering converter services in the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the necessary converter services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the added services.</returns>
    public static IServiceCollection AddConverters(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddTransient<TestResultConverter>();
        return services;
    }
}
