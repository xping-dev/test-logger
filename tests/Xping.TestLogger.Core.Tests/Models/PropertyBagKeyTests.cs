/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;
using Xping.TestLogger.Core.Models;

namespace Xping.TestLogger.Core.Tests.Models;

[TestFixture]
public class PropertyBagKeyTests
{
    [Test]
    public void PropertyBagKeyIsSealed()
    {
        // Assert
        Assert.That(typeof(PropertyBagKey).IsSealed, Is.True);
    }

    [Test]
    public void PropertyBagKeyIsAnnotatedWithDataContract()
    {
        // Assert
        Assert.That(typeof(PropertyBagKey).GetCustomAttributes(typeof(DataContractAttribute), false),
            Has.Length.EqualTo(1));
    }

    [Test]
    public void KeyIsAnnotatedWithDataMember()
    {
        // Arrange
        var keyProperty = typeof(PropertyBagKey).GetProperty(nameof(PropertyBagKey.Key));

        // Assert
        Assert.That(keyProperty, Is.Not.Null);
        Assert.That(keyProperty.GetCustomAttributes(typeof(DataMemberAttribute), false),
            Has.Length.EqualTo(1));
        var dataMemberAttribute =
            (DataMemberAttribute)keyProperty.GetCustomAttributes(typeof(DataMemberAttribute), false)[0];
        Assert.That(dataMemberAttribute.Order, Is.EqualTo(1));
    }

    [Test]
    public void ConstructorWithKeySetsKeyProperty()
    {
        // Arrange
        const string key = "TestKey";

        // Act
        var propertyBagKey = new PropertyBagKey(key);

        // Assert
        Assert.That(propertyBagKey.Key, Is.EqualTo(key));
    }

    [Test]
    public void DefaultConstructorSetsKeyToEmptyString()
    {
        // Act
        var propertyBagKey = new PropertyBagKey();

        // Assert
        Assert.That(propertyBagKey.Key, Is.EqualTo(string.Empty));
    }

    [Test]
    public void ImplicitConversionFromStringSetsKeyProperty()
    {
        // Arrange
        const string key = "TestKey";

        // Act
        PropertyBagKey propertyBagKey = key;

        // Assert
        Assert.That(propertyBagKey.Key, Is.EqualTo(key));
    }

    [Test]
    public void GetDebuggerDisplayReturnsKey()
    {
        // Arrange
        const string key = "TestKey";
        var propertyBagKey = new PropertyBagKey(key);

        // Act
        var debuggerDisplay = propertyBagKey.GetType()
            .GetMethod("GetDebuggerDisplay",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.Invoke(propertyBagKey, null);

        // Assert
        Assert.That(debuggerDisplay, Is.EqualTo(key));
    }
}