namespace MyAnimeList.Net.API.Abstractions.API.Objects.Ranking;

/// <summary>
/// Represents ranking orders.
/// </summary>
public enum RankingType
{
    /// <summary>
    /// Top Anime Series (default).
    /// </summary>
    All,
    
    /// <summary>
    /// Top Airing Anime.
    /// </summary>
    Airing,
    
    /// <summary>
    /// Top Upcoming Anime.
    /// </summary>
    Upcoming,
    
    /// <summary>
    /// Top Anime TV Series.
    /// </summary>
    Tv,
    
    /// <summary>
    /// Top Anime OVA Series.
    /// </summary>
    Ova,
    
    /// <summary>
    /// Top Anime Movies.
    /// </summary>
    Movie,
    
    /// <summary>
    /// Top Anime Specials.
    /// </summary>
    Special,
    
    /// <summary>
    /// Top Anime by Popularity.
    /// </summary>
    Popularity,
    
    /// <summary>
    /// Top Favourited Anime.
    /// </summary>
    Favourite,
    
    /// <summary>
    /// Undocumented.
    /// </summary>
    [Obsolete("This ranking type is not documented.")]
    Trend,
    
    //
    // DOCUMENTED BUT DO NOT WORK
    //
    // /// <summary>
    // /// 1 Hour Ranking: Most Watched.
    // /// </summary>
    // MostWatchedOneHour,
    //
    // /// <summary>
    // /// Daily Ranking: Most Listed Upcoming.
    // /// </summary>
    // MostListedUpcomingOneDay,
    //
    // /// <summary>
    // /// Weekly Ranking: Most Completed.
    // /// </summary>
    // MostCompletedOneWeek
}