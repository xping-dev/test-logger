/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Xping.TestLogger.Core.Models;

namespace Xping.TestLogger.Core.Services.Internals;

/// <summary>
/// A class that provides serialization and deserialization of test sessions
/// </summary>
/// <remarks>
/// This class supports XML format for serialization and deserialization of test sessions.
/// </remarks>
internal sealed class TestSessionSerializer : ITestSessionSerializer
{
    private readonly DataContractSerializer _dataContractSerializer = new(
        type: typeof(TestSession),
        knownTypes: GetKnownTypes());

    /// <summary>
    /// Serializes a test session to a stream using XML format.
    /// </summary>
    /// <param name="session">The test session to serialize</param>
    /// <param name="stream">The stream to save the serialized data</param>
    /// <param name="ownsStream">
    /// True to indicate that the stream is closed by the writer when done, otherwise false
    /// </param>
    void ITestSessionSerializer.Serialize(TestSession session, Stream stream, bool ownsStream)
    {
        //ArgumentNullException.ThrowIfNull(session, nameof(session));
        //ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        try
        {
            using var writer = XmlDictionaryWriter.CreateTextWriter(
                stream, Encoding.UTF8, ownsStream);

            _dataContractSerializer.WriteObject(writer, session);

            // Flush the writer to ensure that all data is written to the stream
            writer.Flush();
            // Reset the stream position to 0
            stream.Position = 0;
        }
        catch (SerializationException ex)
        {
            // Handle serialization exceptions
            // Log the exception or rethrow it as needed
            throw new InvalidOperationException("An error occurred during serialization.", ex);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            // Log the exception or rethrow it as needed
            throw new InvalidOperationException("An unexpected error occurred during serialization.", ex);
        }
    }

    /// <summary>
    /// Deserializes a test session from a stream using XML format.
    /// </summary>
    /// <param name="stream">The stream to load the serialized data</param>
    /// <returns>The deserialized test session</returns>
    /// <exception cref="SerializationException">When incorrect serialization format or data</exception>
    TestSession? ITestSessionSerializer.Deserialize(Stream stream)
    {
        //ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        try
        {
            // Reset the stream position to 0
            stream.Position = 0;

            using var reader = XmlDictionaryReader.CreateTextReader(stream, XmlDictionaryReaderQuotas.Max);
            var result = _dataContractSerializer.ReadObject(reader, true);

            return result as TestSession;
        }
        catch (SerializationException ex)
        {
            // Handle deserialization exceptions
            // Log the exception or rethrow it as needed
            throw new InvalidOperationException("An error occurred during deserialization.", ex);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            // Log the exception or rethrow it as needed
            throw new InvalidOperationException("An unexpected error occurred during deserialization.", ex);
        }
    }

    private static List<Type> GetKnownTypes() =>
    [
        typeof(List<TestCase>),
        typeof(List<TestResult>), 
        typeof(PropertyBag),
        typeof(Dictionary<PropertyBagKey, object>),
        typeof(PropertyBagValue<byte[]>),
        typeof(PropertyBagValue<string>),
        typeof(PropertyBagValue<string[]>),
        typeof(PropertyBagValue<Dictionary<string, string>>),
    ];
}
