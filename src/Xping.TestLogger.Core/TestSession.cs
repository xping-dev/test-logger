/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Diagnostics;
using System.Runtime.Serialization;
using Xping.TestLogger.Core.Models;
using Xping.TestLogger.Core.Services;

namespace Xping.TestLogger.Core;

/// <summary>
/// Represents a test session that contains a collection of test results.
/// </summary>
/// <remarks>
/// A test session encapsulates the execution of a series of tests. The session records the session create time and
/// duration of the tests, and maintains a state indicating its overall status, such as failed, or succeeded.
/// The session can be serialized and deserialized using the <see cref="ITestSessionSerializer"/>, allowing it to be
/// saved, loaded, and transferred between different environments for further analysis and comparison.
/// </remarks>
[DataContract]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class TestSession : IEquatable<TestSession>
{
    /// <summary>
    /// Gets the unique identifier of the test session.
    /// </summary>
    /// <value>
    /// A <see cref="Guid"/> value that represents the test session ID.
    /// </value>
    [DataMember]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the upload token for the test session that links the TestSession's results to the project configured on 
    /// the Xping.io server.
    /// </summary>
    [DataMember]
    public Guid UploadToken { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets the version of the test session class. This is to ensure better compatibility with future schemas.
    /// </summary>
    [DataMember]
    public int Version { get; set; } = 1;

    /// <summary>
    /// Gets the creation date of the test session.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> object that represents the creation time of the test session.
    /// </value>
    [DataMember]
    public DateTime SessionCreateDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Returns a read-only collection of the test results.
    /// </summary>
    [DataMember]
    public List<TestResult>? TestResults { get; set; }

    /// <summary>
    /// Gets the total number of tests in the session.
    /// </summary>
    /// <value>
    /// An integer representing the total number of tests.
    /// </value>
    public int TotalTests => TestResults?.Count ?? 0;

    /// <summary>
    /// Gets the number of tests that failed in the session.
    /// </summary>
    /// <value>
    /// An integer representing the number of tests that failed.
    /// </value>
    public int FailedTests => TestResults?.Count(tr => tr.Outcome == TestOutcome.Failed) ?? 0;

    /// <summary>
    /// Gets the number of tests that passed in the session.
    /// </summary>
    /// <value>
    /// An integer representing the number of tests that passed.
    /// </value>
    public int PassedTests => TestResults?.Count(tr => tr.Outcome == TestOutcome.Passed) ?? 0;

    /// <summary>
    /// Returns a string that represents the current TestSession object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"Total Tests: {TotalTests}, Passed: {PassedTests}, Failed: {FailedTests}";
    }

    /// <summary>
    /// Determines whether the current TestSession object is equal to a specified object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    /// <c>true</c> if the current object and obj are both TestSession objects and have the same id; otherwise, 
    /// <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as TestSession);
    }

    /// <summary>
    /// Determines whether the current TestSession object is equal to another TestSession object.
    /// </summary>
    /// <param name="other">The TestSession object to compare with the current object.</param>
    /// <returns><c>true</c>if the current object and other have the same id; otherwise, <c>false</c>.</returns>
    public bool Equals(TestSession? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id;
    }

    /// <summary>
    /// Determines whether two TestSession objects have the same id.
    /// </summary>
    /// <param name="lhs">The first TestSession object to compare.</param>
    /// <param name="rhs">The second TestSession object to compare.</param>
    /// <returns><c>true</c> if lhs and rhs have the same id; otherwise, <c>false</c>.</returns>
    public static bool operator ==(TestSession? lhs, TestSession? rhs)
    {
        if (lhs is null || rhs is null)
        {
            return Equals(lhs, rhs);
        }

        return lhs.Equals(rhs);
    }

    /// <summary>
    /// Determines whether two TestSession objects have different id.
    /// </summary>
    /// <param name="lhs">The first TestSession object to compare.</param>
    /// <param name="rhs">The second TestSession object to compare.</param>
    /// <returns><c>true</c> if lhs and rhs have different id; otherwise, <c>false</c>.</returns>
    public static bool operator !=(TestSession? lhs, TestSession? rhs)
    {
        if (lhs is null || rhs is null)
        {
            return !Equals(lhs, rhs);
        }

        return !lhs.Equals(rhs);
    }

    /// <summary>
    /// Returns the hash code for the current TestSession object.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
    {
        // Calculate a hash code based on the same properties used in Equals
        return Id.GetHashCode();
    }

    private string GetDebuggerDisplay() => ToString();
}