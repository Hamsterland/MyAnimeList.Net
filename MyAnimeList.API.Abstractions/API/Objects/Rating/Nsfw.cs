namespace MyAnimeList.API.Abstractions.API.Objects.Rating;

/// <summary>
/// Represents the NSFW status.
/// </summary>
public enum Nsfw
{
    /// <summary>
    /// Safe for work.
    /// </summary>
    White,
    
    /// <summary>
    /// May not be safe for work.
    /// </summary>
    Gray,
    
    /// <summary>
    /// Not safe for work.
    /// </summary>
    Black
}