using Remora.Rest.Core;

namespace MyAnimeList.API.Abstractions.API.Objects.Pagination;

/// <summary>
/// A rudimentary entry within a search result.
/// </summary>
/// <typeparam name="TObject">The type of the searched-for object.</typeparam>
public interface IEntry<out TObject>
{
    /// <summary>
    /// Gets the value of the entry.
    /// </summary>
    TObject Node { get; }
    
    /// <summary>
    /// Gets the ranking of the entry,
    /// </summary>
    Optional<object> Rank { get; }
}