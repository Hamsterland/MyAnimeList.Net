using MyAnimeList.API.Abstractions.API.Objects.Favourites;

namespace MyAnimeList.API.Objects.Favourites;

/// <inheritdoc cref="IFavouritesInfo"/> 
public record FavouritesInfo
(
    DateTime AddedAt
) : IFavouritesInfo;