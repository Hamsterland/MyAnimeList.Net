namespace MyAnimeList.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents the media type.
/// </summary>
public enum MediaType
{
    /// <summary>
    /// The media type is unknown.
    /// </summary>
    Unknown,
    
    /// <summary>
    /// TV media.
    /// </summary>
    Tv,
    
    /// <summary>
    /// Original video animation media.
    /// </summary>
    Ova,
    
    /// <summary>
    /// Movie media.
    /// </summary>
    Movie,
    
    /// <summary>
    /// Special media.
    /// </summary>
    Special,
    
    /// <summary>
    /// Original net animation media.
    /// </summary>
    Ona,
    
    /// <summary>
    /// Music media.
    /// </summary>
    Music
}