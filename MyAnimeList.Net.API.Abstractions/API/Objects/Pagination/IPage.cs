namespace MyAnimeList.Net.API.Abstractions.API.Objects.Pagination;

/// <summary>
/// Represents a pagination object.
/// </summary>
/// <typeparam name="TObject">The type of the paginated object.</typeparam>
public interface IPage<out TObject>
{
    /// <summary>
    /// Gets the searched-for results.
    /// </summary>
    IReadOnlyList<IEntry<TObject>> Data { get; }
    
    /// <summary>
    /// Gets the paging information.
    /// </summary>
    IPaging Paging { get; }
}