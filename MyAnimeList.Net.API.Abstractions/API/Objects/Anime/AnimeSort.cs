namespace MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

/// <summary>
/// The sort filters for an anime search.
/// </summary>
public enum AnimeSort
{
    /// <summary>
    /// Sort by score.
    /// </summary>
    Score,
    /// <summary>
    /// Sort by the number of users who have this anime on their list.
    /// </summary>
    ListUsersCount,
    
    /// <summary>
    /// Sort by the start date.
    /// </summary>
    StartDate,
    
    /// <summary>
    /// Sort by the database entry creation date.
    /// </summary>
    CreatedAt
}