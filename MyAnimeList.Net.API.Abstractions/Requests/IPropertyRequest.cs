using System.Collections.Generic;
using System.Reflection;

namespace MyAnimeList.Net.API.Abstractions.Requests;

/// <summary>
/// Represents a marker interface for requests.
/// </summary>
public interface IPropertyRequest
{
    /// <summary>
    /// Gets the list of the properties to be returned for this request.
    /// </summary>
    IReadOnlyList<PropertyInfo> RequestedProperties { get; }
}