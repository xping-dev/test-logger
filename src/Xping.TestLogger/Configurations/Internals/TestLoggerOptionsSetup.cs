/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Microsoft.Extensions.Options;

namespace Xping.TestLogger.Configurations.Internals;

internal sealed class TestLoggerOptionsSetup(TestLoggerParameters parameters) : IConfigureOptions<TestLoggerOptions>
{
    public void Configure(TestLoggerOptions options)
    {
        options.TestRunDirectory = parameters.TestRunDirectory;
    }

    /*
    /// <summary>
    /// Parses the provided <see cref="TestLoggerParameters"/> and sets the corresponding properties.
    /// </summary>
    /// <param name="parameters">The parameters to parse.</param>
    public void Parse(TestLoggerParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        // Create a case-insensitive dictionary
        var caseInsensitiveParameters = GetCaseInsensitiveDictionary(parameters.AdditionalParameters);

        UploadToken = GetParameter<Guid>(caseInsensitiveParameters, "UploadToken");
    }

    private static Dictionary<string, string?> GetCaseInsensitiveDictionary(
        IReadOnlyDictionary<string, string?>? additionalParameters)
    {
        if (additionalParameters is null)
            return new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

        return new Dictionary<string, string?>(additionalParameters, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Gets a parameter from the case-insensitive dictionary and converts it to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the parameter to.</typeparam>
    /// <param name="parameters">The dictionary containing the parameters.</param>
    /// <param name="key">The key of the parameter to get.</param>
    /// <returns>The parameter converted to the specified type.</returns>
    /// <exception cref="ArgumentException">Thrown when the parameter cannot be converted to the specified type.</exception>
    private static T? GetParameter<T>(Dictionary<string, string?> parameters, string key)
    {
        if (parameters.TryGetValue(key, out var value))
        {
            try
            {
                return (T?)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"The parameter '{key}' cannot be converted to type {typeof(T).Name}.", ex);
            }
        }

        throw new ArgumentException($"The parameter '{key}' was not found in the dictionary.");
    }
*/
}
