namespace MyAnimeList.API.Abstractions.API.Objects.Favourites;
    
/// <summary>
/// Represents a favourites entry information.
/// </summary>
public interface IFavouritesInfo
{
    /// <summary>
    /// Gets the time the entry was added to the favourites.
    /// </summary>
    DateTime AddedAt { get; }
}