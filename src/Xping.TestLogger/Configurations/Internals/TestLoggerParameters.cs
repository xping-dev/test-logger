/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

namespace Xping.TestLogger.Configurations.Internals;

/// <summary>
/// This class serves as a wrapper of various test logger parameters provided by the test framework or test runner, 
/// such as Visual Studio Test Platform (VSTest), providing a centralized repository for their storage.
/// </summary>
public class TestLoggerParameters
{
    /// <summary>
    /// Gets or sets the directory where the test run is executed. This property can be null.
    /// </summary>
    public string? TestRunDirectory { get; }

    /// <summary>
    /// Gets or sets additional parameters for the test logger. This property can be null.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? AdditionalParameters { get; }

    /// <summary>
    /// Initializes a new instance with the specified test run directory.
    /// </summary>
    /// <param name="testRunDirectory">The directory where the test run is executed.</param>
    public TestLoggerParameters(string testRunDirectory)
    {
        TestRunDirectory = testRunDirectory;
    }

    /// <summary>
    /// Initializes a new instance with the specified additional parameters.
    /// </summary>
    /// <param name="additionalParameters">A dictionary containing additional parameters for the test logger.</param>
    public TestLoggerParameters(Dictionary<string, string?> additionalParameters)
    {
        AdditionalParameters = additionalParameters;
    }
}
