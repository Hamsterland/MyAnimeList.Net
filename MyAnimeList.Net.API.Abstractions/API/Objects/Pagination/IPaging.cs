using Remora.Rest.Core;

namespace MyAnimeList.Net.API.Abstractions.API.Objects.Pagination;

/// <summary>
/// Represents the forward and backward pagination links.
/// </summary>
public interface IPaging
{
    /// <summary>
    /// Gets the link to the next page.
    /// </summary>
    Optional<string> Next { get; }
    
    /// <summary>
    /// Gets the link to the previous page.
    /// </summary>
    Optional<string> Previous { get; }
}