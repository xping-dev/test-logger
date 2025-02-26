/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using Xping.TestLogger.Core.Models;

namespace Xping.TestLogger.Core.Tests;

[TestFixture]
public class TestSessionTests
{
    [Test]
    public void TestSessionInitializationSetsDefaultValues()
    {
        // Arrange
        var before = DateTime.Now;

        // Act
        var testSession = new TestSession { UploadToken = Guid.NewGuid() };
        var after = DateTime.Now;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(testSession.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(testSession.Version, Is.EqualTo(1));
            Assert.That(testSession.SessionCreateDate, Is.InRange(before, after));
            Assert.That(testSession.TestResults, Is.Null);
        });
    }

    [Test]
    public void EqualsSameIdReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var session1 = new TestSession { Id = id, UploadToken = Guid.NewGuid() };
        var session2 = new TestSession { Id = id, UploadToken = Guid.NewGuid() };

        // Act
        var result = session1.Equals(session2);

        // Assert
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void EqualsDifferentIdReturnsFalse()
    {
        // Arrange
        var session1 = new TestSession { UploadToken = Guid.NewGuid() };
        var session2 = new TestSession { UploadToken = Guid.NewGuid() };

        // Act
        var result = session1.Equals(session2);

        // Assert
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void GetHashCodeSameIdReturnsSameHashCode()
    {
        // Arrange
        var id = Guid.NewGuid();
        var session1 = new TestSession { Id = id, UploadToken = Guid.NewGuid() };
        var session2 = new TestSession { Id = id, UploadToken = Guid.NewGuid() };

        // Act
        var hashCode1 = session1.GetHashCode();
        var hashCode2 = session2.GetHashCode();

        // Assert
        Assert.That(hashCode1, Is.EqualTo(hashCode2));
    }

    [Test]
    public void ToStringReturnsExpectedString()
    {
        // Arrange
        var id = Guid.NewGuid();
        var sessionCreateDate = DateTime.UtcNow;
        var results = new List<TestResult>();
        var testSession = new TestSession
        {
            Id = id,
            UploadToken = Guid.NewGuid(),
            SessionCreateDate = sessionCreateDate,
            TestResults = results
        };

        // Act
        var result = testSession.ToString();

        // Assert
        var expectedString =
            $"TestSession [ID: {id.ToString()[..8]}] [Created: {sessionCreateDate}] [Version: 1] [Results Count: {results.Count}]";
        Assert.That(expectedString, Is.EqualTo(result));
    }

    [Test]
    public void OperatorEqualsSameIdReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var session1 = new TestSession { Id = id, UploadToken = Guid.NewGuid() };
        var session2 = new TestSession { Id = id, UploadToken = Guid.NewGuid() };

        // Act
        var result = session1 == session2;

        // Assert
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void OperatorNotEqualsDifferentIdReturnsTrue()
    {
        // Arrange
        var session1 = new TestSession { UploadToken = Guid.NewGuid() };
        var session2 = new TestSession { UploadToken = Guid.NewGuid() };

        // Act
        var result = session1 != session2;

        // Assert
        Assert.That(result, Is.EqualTo(true));
    }
}