/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Xping.TestLogger.Core;
using ObjectModelTestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;

namespace Xping.TestLogger.Services;

/// <summary>
/// Interface for building a test session with various configurations.
/// </summary>
public interface ITestSessionBuilder
{
    /// <summary>
    /// Configures the builder with a start date.
    /// </summary>
    /// <param name="startDate">The start date of the test session.</param>
    /// <returns>The current instance of the builder.</returns>
    ITestSessionBuilder WithStartDate(DateTime startDate);

    /// <summary>
    /// Configures the builder with an upload token.
    /// </summary>
    /// <param name="uploadToken">The upload token to be used in the test session.</param>
    /// <returns>The current instance of the builder.</returns>
    ITestSessionBuilder WithUploadToken(Guid uploadToken);

    /// <summary>
    /// Configures the builder with a version number.
    /// </summary>
    /// <param name="version">The version number of the test session.</param>
    /// <returns>The current instance of the builder.</returns>
    ITestSessionBuilder WithVersion(int version);

    /// <summary>
    /// Configures the builder with a test result.
    /// </summary>
    /// <param name="testResult">The test result to be included in the test session.</param>
    /// <returns>The current instance of the builder.</returns>
    ITestSessionBuilder WithTestResult(ObjectModelTestResult testResult);

    /// <summary>
    /// Resets the session builder to its initial state.
    /// </summary>
    void Reset();

    /// <summary>
    /// Builds and returns the configured test session.
    /// </summary>
    /// <returns>The configured test session.</returns>
    TestSession Build();
}
