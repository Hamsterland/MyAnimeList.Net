namespace MyAnimeList.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents an animation/production studio.
/// </summary>
public interface IStudio
{
    /// <summary>
    /// Gets the ID of the studio.
    /// </summary>
    int ID { get; }
    
    /// <summary>
    /// Gets the name of the studio.
    /// </summary>
    string Name { get; }
}