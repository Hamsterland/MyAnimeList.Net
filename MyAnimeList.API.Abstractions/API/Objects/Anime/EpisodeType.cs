namespace MyAnimeList.API.Abstractions.API.Objects.Anime;

/// <summary>
/// The possible types for an episode.
/// </summary>
public enum EpisodeType
{
    /// <summary>
    /// A main episode.
    /// </summary>
    Main,
    
    /// <summary>
    /// A recap/summary episode.
    /// </summary>
    Recap,
    
    /// <summary>
    /// A filler episode.
    /// </summary>
    Filler
}