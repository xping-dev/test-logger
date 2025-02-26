/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;

namespace Xping.TestLogger.Core.Models;

/// <summary>
/// Represents a serializable property bag value.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
[DataContract]
public sealed class PropertyBagValue<TValue>
{
    /// <summary>
    /// Gets or sets the value of the serializable property bag value.
    /// </summary>
    [DataMember(Order = 1)]
    public TValue? Value { get; set; }

    /// <summary>
    /// Parameterless constructor for serialization.
    /// </summary>
    public PropertyBagValue()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyBagValue{TValue}"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value of the serializable property bag value.</param>
    public PropertyBagValue(TValue value)
    {
        Value = value;
    }
}
