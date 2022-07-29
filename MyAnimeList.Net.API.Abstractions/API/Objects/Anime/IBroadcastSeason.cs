namespace MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents a release season.
/// </summary>
public interface IBroadcastSeason
{
    /// <summary>
    /// Gets the broadcast year.
    /// </summary>
    int Year { get; }
    
    /// <summary>
    /// Gets the broadcast season.
    /// </summary>
    Season Season { get; }
}