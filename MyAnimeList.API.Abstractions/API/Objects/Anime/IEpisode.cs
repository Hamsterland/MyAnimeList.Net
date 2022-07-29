using MyAnimeList.API.Abstractions.API.Objects.Movies;
using MyAnimeList.API.Abstractions.API.Objects.Titles;
using Remora.Rest.Core;

namespace MyAnimeList.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents an anime episode.
/// </summary>
public interface IEpisode
{
    /// <summary>
    /// Gets the episode ID.
    /// </summary>
    int ID { get; }
    
    /// <summary>
    /// Gets the episode number.
    /// </summary>
    int Number { get; }
    
    /// <summary>
    /// Gets the episode title.
    /// </summary>
    Optional<string?> Title { get; }

    /// <summary>
    /// Gets the alternative titles for the episode.
    /// </summary>
    Optional<ITitle> AlternativeTitles { get; }
    
    /// <summary>
    /// Gets the type of episode.
    /// </summary>
    Optional<EpisodeType> Type { get; }
    
    /// <summary>
    /// Gets the synopsis of the episode.
    /// </summary>
    Optional<string?> Synopsis { get; }
    
    /// <summary>
    /// Gets the aired date of the episode.
    /// </summary>
    Optional<DateOnly> AiredDate { get; }
    
    /// <summary>
    /// Gets the length of the episode.
    /// </summary>
    Optional<TimeSpan> Length { get; }
    
    /// <summary>
    /// Gets the videos of the episode.
    /// </summary>
    Optional<IReadOnlyList<IMovie>> Videos { get; }
}