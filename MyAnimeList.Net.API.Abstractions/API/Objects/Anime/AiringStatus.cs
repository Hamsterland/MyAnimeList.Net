namespace MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents the airing status.
/// </summary>
public enum AiringStatus
{
    /// <summary>
    /// The media has finished airing.
    /// </summary>
    FinishedAiring,
    
    /// <summary>
    /// The media is currently airing.
    /// </summary>
    CurrentlyAiring,
    
    /// <summary>
    /// The media has not yet aired.
    /// </summary>
    NotYetAired
}