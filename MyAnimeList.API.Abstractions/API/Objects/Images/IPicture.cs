namespace MyAnimeList.API.Abstractions.API.Objects.Images;

/// <summary>
/// Represents an image or picture.
/// </summary>
public interface IPicture
{
    /// <summary>
    /// Gets the URL to the large size.
    /// </summary>
    string? Large { get; }
    
    /// <summary>
    /// Gets the URL to the medium size.
    /// </summary>
    string Medium { get; }
}