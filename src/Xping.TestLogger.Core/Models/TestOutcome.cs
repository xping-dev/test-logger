/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

namespace Xping.TestLogger.Core.Models;

/// <summary>
/// Represents the possible outcomes of a test.
/// </summary>
public enum TestOutcome
{
    /// <summary>
    /// The test outcome is not specified.
    /// </summary>
    None,

    /// <summary>
    /// The test passed successfully.
    /// </summary>
    Passed,

    /// <summary>
    /// The test failed.
    /// </summary>
    Failed,

    /// <summary>
    /// The test was skipped.
    /// </summary>
    Skipped,

    /// <summary>
    /// The test was not found.
    /// </summary>
    NotFound
}
