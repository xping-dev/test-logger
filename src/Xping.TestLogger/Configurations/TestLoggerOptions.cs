/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

namespace Xping.TestLogger.Configurations;

/// <summary>
/// Represents the options for the TestLogger.
/// </summary>
public class TestLoggerOptions
{
    /// <summary>
    /// Gets or sets the directory where test run data is stored.
    /// </summary>
    public string? TestRunDirectory { get; set; }

    /// <summary>
    /// Gets or sets the token used for uploading test results.
    /// </summary>
    public Guid UploadToken { get; set; }

    /// <summary>
    /// Gets or sets the upload server URI.
    /// </summary>
    public Uri UploadServer { get; set; } = new Uri("https://localhost:7100/api/upload");

    /// <summary>
    /// Gets or sets the version of the test session class.
    /// </summary>
    public int Version { get; set; } = 1;
}
