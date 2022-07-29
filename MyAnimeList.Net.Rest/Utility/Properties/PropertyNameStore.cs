using System.Collections.Generic;
using System.Reflection;

namespace MyAnimeList.Net.Rest.Utility.Properties;

/// <summary>
/// Represents a storage class for both requested properties and their associated field name.
/// </summary>
public class PropertyNameStore
{
    /// <summary>
    /// The requested properties.
    /// </summary>
    public IReadOnlyList<PropertyInfo> RequestedProperties { get; }
    
    /// <summary>
    /// The associated field names for the requested properties.
    /// </summary>
    public IReadOnlyList<string> RequestPropertyFieldNames { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyNameStore"/> class.
    /// </summary>
    /// <param name="requestedProperties">The requested properties.</param>
    /// <param name="requestPropertyFieldNames">The associated field names for the properties,.</param>
    public PropertyNameStore(IReadOnlyList<PropertyInfo> requestedProperties, IReadOnlyList<string> requestPropertyFieldNames)
    {
        RequestedProperties = requestedProperties;
        RequestPropertyFieldNames = requestPropertyFieldNames;
    }

    /// <summary>
    /// Converts the <see cref="RequestPropertyFieldNames"/> to a field query string.
    /// </summary>
    /// <returns>The converted field query string.</returns>
    public string ToFieldString()
    {
        return string.Join(",", RequestPropertyFieldNames);
    }
}