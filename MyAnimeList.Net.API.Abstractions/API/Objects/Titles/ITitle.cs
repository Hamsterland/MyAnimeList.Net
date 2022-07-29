using Remora.Rest.Core;

namespace MyAnimeList.Net.API.Abstractions.API.Objects.Titles;

/// <summary>
/// Represents a title and its synonyms.
/// </summary>
public interface ITitle
{
    /// <summary>
    /// Gets the synonyms of the title.
    /// </summary>
    Optional<IReadOnlyList<string?>> Synonyms { get; }
    
    /// <summary>
    /// Gets the English title.
    /// </summary>
    Optional<string?> English { get; }
    
    /// <summary>
    /// Gets the Japanese title.
    /// </summary>
    Optional<string?> Japanese { get; }
}