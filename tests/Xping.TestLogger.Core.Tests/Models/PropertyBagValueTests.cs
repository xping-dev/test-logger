/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;
using Xping.TestLogger.Core.Models;

namespace Xping.TestLogger.Core.Tests.Models;

[TestFixture]
public class PropertyBagValueTests
{
    [Test]
    public void PropertyBagValueIsSealed()
    {
        // Assert
        Assert.That(typeof(PropertyBagValue<>).IsSealed, Is.True);
    }

    [Test]
    public void PropertyBagValueIsAnnotatedWithDataContract()
    {
        // Assert
        Assert.That(typeof(PropertyBagValue<>).GetCustomAttributes(typeof(DataContractAttribute), false),
            Has.Length.EqualTo(1));
    }

    [Test]
    public void ValueIsAnnotatedWithDataMember()
    {
        // Arrange
        var valueProperty = typeof(PropertyBagValue<>).GetProperty(nameof(PropertyBagValue<object>.Value));

        // Assert
        Assert.That(valueProperty?.GetCustomAttributes(typeof(DataMemberAttribute), false).Length, Is.EqualTo(1));
        var dataMemberAttribute =
            (DataMemberAttribute)valueProperty.GetCustomAttributes(typeof(DataMemberAttribute), false)[0];
        Assert.That(dataMemberAttribute.Order, Is.EqualTo(1));
    }

    [Test]
    public void ConstructorWithValueSetsValueProperty()
    {
        // Arrange
        var value = "TestValue";

        // Act
        var propertyBagValue = new PropertyBagValue<string>(value);

        // Assert
        Assert.That(propertyBagValue.Value, Is.EqualTo(value));
    }

    [Test]
    public void DefaultConstructorSetsValueToNull()
    {
        // Act
        var propertyBagValue = new PropertyBagValue<string>();

        // Assert
        Assert.That(propertyBagValue.Value, Is.Null);
    }
}
