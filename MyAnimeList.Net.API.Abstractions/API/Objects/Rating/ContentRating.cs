namespace MyAnimeList.Net.API.Abstractions.API.Objects.Rating;

/// <summary>
/// Represents the content rating.
/// </summary>
public enum ContentRating
{
    /// <summary>
    /// All ages.
    /// </summary>
    G,
    
    /// <summary>
    /// Children.
    /// </summary>
    Pg,
    
    /// <summary>
    /// Teens 13 and older.
    /// </summary>
    Pg13,
    
    /// <summary>
    /// 17+ violence and profanity.
    /// </summary>
    R,
    
    /// <summary>
    /// Profanity and mild nudity.
    /// </summary>
    Rp,
    
    /// <summary>
    /// Hentai.
    /// </summary>
    Rx
}