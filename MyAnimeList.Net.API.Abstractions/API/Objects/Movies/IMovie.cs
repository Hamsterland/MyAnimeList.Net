namespace MyAnimeList.Net.API.Abstractions.API.Objects.Movies;

/// <summary>
/// Represents a movie or video.
/// </summary>
public interface IMovie
{
    /// <summary>
    /// Gets the title of the movie.
    /// </summary>
    string? Title { get; }
    
    /// <summary>
    /// Gets the URI of the movie.
    /// </summary>
    string? Url { get; }
    
    /// <summary>
    /// Gets the player URI of the movie.
    /// </summary>
    string? PlayerUrl { get; }
    
    /// <summary>
    /// Gets the thumbnail URI of the movie.
    /// </summary>
    string? ThumbnailUrl { get; }
}