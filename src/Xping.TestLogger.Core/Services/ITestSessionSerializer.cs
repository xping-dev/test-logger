/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

namespace Xping.TestLogger.Core.Services;

/// <summary>
/// Interface for serialization and deserialization of test sessions.
/// </summary>
public interface ITestSessionSerializer
{
    /// <summary>
    /// Serializes the specified test session to the provided stream.
    /// </summary>
    /// <param name="session">The test session to serialize.</param>
    /// <param name="stream">The stream to which the session will be serialized.</param>
    /// <param name="ownsStream">If set to <c>true</c>, the stream will be closed after serialization.</param>
    void Serialize(TestSession session, Stream stream, bool ownsStream = false);

    /// <summary>
    /// Deserializes a test session from the provided stream.
    /// </summary>
    /// <param name="stream">The stream from which the session will be deserialized.</param>
    /// <returns>The deserialized test session, or <c>null</c> if deserialization fails.</returns>
    TestSession? Deserialize(Stream stream);
}
