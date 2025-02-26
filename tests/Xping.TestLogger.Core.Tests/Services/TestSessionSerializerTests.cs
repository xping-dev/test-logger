/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Text;
using Xping.TestLogger.Core.Models;
using Xping.TestLogger.Core.Services;
using Xping.TestLogger.Core.Services.Internals;

namespace Xping.TestLogger.Core.Tests.Services;

[TestFixture]
public class TestSessionSerializerTests
{
    private ITestSessionSerializer _serializer;

    [SetUp]
    public void SetUp()
    {
        _serializer = new TestSessionSerializer();
    }

    [Test]
    public void SerializeNullSessionThrowsArgumentNullException()
    {
        // Arrange
        TestSession session = null!;
        using var stream = new MemoryStream();

        // Act & Assert
        Assert.That(() => _serializer.Serialize(session, stream), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void SerializeNullStreamThrowsArgumentNullException()
    {
        // Arrange
        var session = new TestSession { UploadToken = Guid.NewGuid() };
        Stream stream = null!;

        // Act & Assert
        Assert.That(() => _serializer.Serialize(session, stream), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void SerializeValidSessionSerializesCorrectly()
    {
        // Arrange
        var session = new TestSession
        {
            Id = Guid.NewGuid(),
            UploadToken = Guid.NewGuid(),
            Version = 1,
            SessionCreateDate = DateTime.UtcNow,
            TestResults =
            [
                new TestResult
                {
                    TestCase = new TestCase
                    {
                        FullyQualifiedName = "Test1",
                        ExecutorUri = new Uri("logger://xping/logger/v1"),
                        Source = "Test1",
                        CodeFilePath = "Test1.cs"
                    },
                    ComputerName = "Computer1",
                    Duration = TimeSpan.FromSeconds(1),
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(5),
                    DisplayName = "Test1",
                    ErrorMessage = "Error1",
                    ErrorStackTrace = "StackTrace1",
                    Outcome = TestOutcome.Failed
                }
            ]
        };

        using var stream = new MemoryStream();

        // Act
        _serializer.Serialize(session, stream);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        var serializedString = reader.ReadToEnd();

        // Assert
        Assert.That(serializedString, Is.Not.Empty);
    }


    [Test]
    public void DeserializeNullStreamThrowsArgumentNullException()
    {
        // Arrange
        Stream stream = null!;

        // Act & Assert
        Assert.That(() => _serializer.Deserialize(stream), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void DeserializeValidStreamDeserializesCorrectly()
    {
        // Arrange
        string[] values = ["Value2", "Value3"];

        var propertyBag = new PropertyBag();
        propertyBag.Add("Key1", "Value1");
        propertyBag.Add("Key2", values);

        var session = new TestSession
        {
            Id = Guid.NewGuid(),
            UploadToken = Guid.NewGuid(),
            Version = 1,
            SessionCreateDate = DateTime.UtcNow,
            TestResults =
            [
                new TestResult
                {
                    TestCase = new TestCase
                    {
                        FullyQualifiedName = "Test1",
                        ExecutorUri = new Uri("logger://xping/logger/v1"),
                        Source = "Test1",
                        CodeFilePath = "Test1.cs"
                    },
                    ComputerName = "Computer1",
                    Duration = TimeSpan.FromSeconds(1),
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(5),
                    DisplayName = "Test1",
                    ErrorMessage = "Error1",
                    ErrorStackTrace = "StackTrace1",
                    Outcome = TestOutcome.Failed
                }
            ]
        };

        using var stream = new MemoryStream();
        //_serializer.Serialize(session, stream);


        var fileStream = new FileStream("serialized.xml", FileMode.Open);
        fileStream.CopyTo(stream);
        stream.Position = 0;

        // Act
        var deserializedSession = _serializer.Deserialize(stream);

        // Assert
        Assert.That(deserializedSession, Is.Not.Null);
        Assert.That(deserializedSession.Id, Is.EqualTo(session.Id));
        Assert.That(deserializedSession.UploadToken, Is.EqualTo(session.UploadToken));
        Assert.That(deserializedSession.Version, Is.EqualTo(session.Version));
        Assert.That(deserializedSession.SessionCreateDate, Is.EqualTo(session.SessionCreateDate));
    }

    [Test]
    public void DeserializeInvalidStreamThrowsInvalidOperationException()
    {
        // Arrange
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("Invalid XML"));

        // Act & Assert
        Assert.That(() => _serializer.Deserialize(stream), Throws.TypeOf<InvalidOperationException>());
    }
}