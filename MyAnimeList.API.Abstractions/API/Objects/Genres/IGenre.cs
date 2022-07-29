namespace MyAnimeList.API.Abstractions.API.Objects.Genres;

/// <summary>
/// Represents a genre.
/// </summary>
public interface IGenre
{
    /// <summary>
    /// Gets the genre ID.
    /// </summary>
    int ID { get;  }
    
    /// <summary>
    /// Gets the genre name.
    /// </summary>
    string Name { get; }
}