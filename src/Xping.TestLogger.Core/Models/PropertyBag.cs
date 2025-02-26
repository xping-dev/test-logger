/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Runtime.Serialization;

namespace Xping.TestLogger.Core.Models;

/// <summary>
/// PropertyBag class represents a collection of key-value pairs that allows to store any object for a given unique key.
/// All keys are represented by <see cref="PropertyBagKey"/> but values may be of any type.
/// </summary>
[DataContract]
public sealed class PropertyBag
{
    /// <summary>
    /// Gets the dictionary of properties stored in the PropertyBag.
    /// </summary>
    [DataMember(Order = 1)]
    public Dictionary<PropertyBagKey, object> Properties { get; private set; } = [];

    /// <summary>
    /// Initializes an empty instance of the PropertyBag class.
    /// </summary>
    public PropertyBag()
    { }

    /// <summary>
    /// Adds a value to the PropertyBag with the specified key.
    /// </summary>
    /// <typeparam name="TValue">The type of the value to add.</typeparam>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">The value to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the key is null.</exception>
    public void Add<TValue>(PropertyBagKey key, TValue value)
    {
        //ArgumentNullException.ThrowIfNull(key);

        Properties[key] = new PropertyBagValue<TValue>(value);
    }

    /// <summary>
    /// Gets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="TValue">The type of the value to get.</typeparam>
    /// <param name="key">The key associated with the value.</param>
    /// <returns>The value associated with the specified key.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the key is not found in the PropertyBag.</exception>
    public TValue? Get<TValue>(PropertyBagKey key)
    {
        //ArgumentNullException.ThrowIfNull(key);

        if (Properties.TryGetValue(key, out var propertyValue) &&
            propertyValue is PropertyBagValue<TValue> propertyBagValue)
        {
            return propertyBagValue.Value;
        }

        throw new KeyNotFoundException($"Key '{key.Key}' not found.");
    }

    /// <summary>
    /// Tries to get the value associated with the specified key.
    /// </summary>
    /// <typeparam name="TValue">The type of the value to get.</typeparam>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">
    /// When this method returns, contains the value associated with the specified key, if the key is found; 
    /// otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.
    /// </param>
    /// <returns>true if the PropertyBag contains an element with the specified key; otherwise, false.</returns>
    public bool TryGet<TValue>(PropertyBagKey key, out TValue? value)
    {
        value = default;

        if (Properties.TryGetValue(key, out var propertyValue) &&
            propertyValue is PropertyBagValue<TValue> propertyBagValue)
        {
            value = propertyBagValue.Value;
            return true;
        }

        return false;
    }
}
