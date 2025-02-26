/*
 * © 2025 Xping.io. All Rights Reserved.
 *
 * License: [MIT]
 */

using System.Diagnostics;
using System.Runtime.Serialization;

namespace Xping.TestLogger.Core.Models;

/// <summary>
/// Represents a key for a property bag.
/// </summary>
[DataContract]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class PropertyBagKey
{
    /// <summary>
    /// Gets the key string.
    /// </summary>
    [DataMember(Order = 1)]
    public string Key { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyBagKey"/> class for serialization.
    /// </summary>
    public PropertyBagKey() : this(string.Empty)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyBagKey"/> class with the specified key.
    /// </summary>
    /// <param name="key">The key string.</param>
    public PropertyBagKey(string key)
    {
        Key = key;
    }

    /// <summary>
    /// Implicitly converts a string to a <see cref="PropertyBagKey"/>.
    /// </summary>
    /// <param name="key">The key string.</param>
    public static implicit operator PropertyBagKey(string key) => new(key);

    private string GetDebuggerDisplay() => Key;
}