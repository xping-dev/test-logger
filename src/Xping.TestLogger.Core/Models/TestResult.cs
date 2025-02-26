// /*
//  * © 2025 Xping.io. All Rights Reserved.
//  *
//  * License: [MIT]
//  */

using System.Runtime.Serialization;

namespace Xping.TestLogger.Core.Models;

/// <summary>
/// Represents the result of a test execution, including details about the test case, 
/// execution environment, and outcome.
/// </summary>
[DataContract]
public sealed class TestResult
{
    /// <summary>
    /// Gets or sets the test case associated with this test result.
    /// </summary>
    [DataMember]
    public TestCase? TestCase { get; set; }

    /// <summary>
    /// Gets or sets the name of the computer where the test was executed.
    /// </summary>
    [DataMember]
    public string? ComputerName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the test result.
    /// </summary>
    [DataMember]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the duration of the test execution.
    /// </summary>
    [DataMember]
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Gets or sets the end time of the test execution.
    /// </summary>
    [DataMember]
    public DateTimeOffset EndTime { get; set; }

    /// <summary>
    /// Gets or sets the error message if the test failed.
    /// </summary>
    [DataMember]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the stack trace of the error if the test failed.
    /// </summary>
    [DataMember]
    public string? ErrorStackTrace { get; set; }

    /// <summary>
    /// Gets or sets the outcome of the test execution.
    /// </summary>
    [DataMember]
    public TestOutcome Outcome { get; set; }

    /// <summary>
    /// Gets or sets the start time of the test execution.
    /// </summary>
    [DataMember]
    public DateTimeOffset StartTime { get; set; }
}
