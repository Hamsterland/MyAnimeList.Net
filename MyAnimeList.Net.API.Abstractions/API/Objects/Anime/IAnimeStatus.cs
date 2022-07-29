namespace MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents the list status of an anime.
/// </summary>
public interface IAnimeStatus
{
    /// <summary>
    /// Gets the number of users who are watching the anime.
    /// </summary>
    int Watching { get; }
    
    /// <summary>
    /// Gets the number of users who have completed the anime.
    /// </summary>
    int Completed { get; }
    
    /// <summary>
    /// Gets the number of users who have put the anime on-hold.
    /// </summary>
    int OnHold { get; }
    
    /// <summary>
    /// Gets the number of users who have dropped the anime.
    /// </summary>
    int Dropped { get; }
    
    /// <summary>
    /// Gets the number of users who have planned to watch the anime.
    /// </summary>
    int PlanToWatch { get; }
}