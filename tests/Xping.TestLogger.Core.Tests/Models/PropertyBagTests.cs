/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;
using Xping.TestLogger.Core.Models;

namespace Xping.TestLogger.Core.Tests.Models;

[TestFixture]
public class PropertyBagTests
{
    [Test]
    public void PropertyBagIsSealed()
    {
        // Assert
        Assert.That(typeof(PropertyBag).IsSealed, Is.True);
    }

    [Test]
    public void PropertyBagIsAnnotatedWithDataContract()
    {
        // Assert
        Assert.That(typeof(PropertyBag).GetCustomAttributes(typeof(DataContractAttribute), false),
            Has.Length.EqualTo(1));
    }

    [Test]
    public void PropertiesIsAnnotatedWithDataMember()
    {
        // Arrange
        var propertiesProperty = typeof(PropertyBag).GetProperty(nameof(PropertyBag.Properties));

        // Assert
        Assert.That(propertiesProperty?.GetCustomAttributes(typeof(DataMemberAttribute), false).Length, Is.EqualTo(1));
        var dataMemberAttribute =
            (DataMemberAttribute)propertiesProperty.GetCustomAttributes(typeof(DataMemberAttribute), false)[0];
        Assert.That(dataMemberAttribute.Order, Is.EqualTo(1));
    }

    [Test]
    public void ConstructorInitializesEmptyProperties()
    {
        // Act
        var propertyBag = new PropertyBag();

        // Assert
        Assert.That(propertyBag.Properties, Is.Not.Null);
        Assert.That(propertyBag.Properties, Is.Empty);
    }

    [Test]
    public void AddAddsValueToProperties()
    {
        // Arrange
        var propertyBag = new PropertyBag();
        var key = new PropertyBagKey("TestKey");
        var value = "TestValue";

        // Act
        propertyBag.Add(key, value);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(propertyBag.Properties.ContainsKey(key), Is.True);
            Assert.That(propertyBag.Properties[key], Is.InstanceOf<PropertyBagValue<string>>());
            Assert.That(((PropertyBagValue<string>)propertyBag.Properties[key]).Value, Is.EqualTo(value));
        });
    }

    [Test]
    public void AddNullKeyThrowsArgumentNullException()
    {
        // Arrange
        var propertyBag = new PropertyBag();
        PropertyBagKey key = null!;
        var value = "TestValue";

        // Act & Assert
        Assert.That(() => propertyBag.Add(key, value), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void GetReturnsValueForKey()
    {
        // Arrange
        var propertyBag = new PropertyBag();
        var key = new PropertyBagKey("TestKey");
        var value = "TestValue";
        propertyBag.Add(key, value);

        // Act
        var result = propertyBag.Get<string>(key);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void GetNonExistentKeyThrowsKeyNotFoundException()
    {
        // Arrange
        var propertyBag = new PropertyBag();
        var key = new PropertyBagKey("NonExistentKey");

        // Act & Assert
        Assert.That(() => propertyBag.Get<string>(key), Throws.TypeOf<KeyNotFoundException>());
    }

    [Test]
    public void TryGetReturnsTrueAndValueForKey()
    {
        // Arrange
        var propertyBag = new PropertyBag();
        var key = new PropertyBagKey("TestKey");
        var value = "TestValue";
        propertyBag.Add(key, value);

        // Act
        var result = propertyBag.TryGet(key, out string? resultValue);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(resultValue, Is.EqualTo(value));
        });
    }

    [Test]
    public void TryGetReturnsFalseForNonExistentKey()
    {
        // Arrange
        var propertyBag = new PropertyBag();
        var key = new PropertyBagKey("NonExistentKey");

        // Act
        var result = propertyBag.TryGet(key, out string? resultValue);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(resultValue, Is.Null);
        });
    }
}
