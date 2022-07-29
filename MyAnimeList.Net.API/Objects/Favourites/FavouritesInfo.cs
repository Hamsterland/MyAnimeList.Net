using MyAnimeList.Net.API.Abstractions.API.Objects.Favourites;

namespace MyAnimeList.Net.API.Objects.Favourites;

/// <inheritdoc cref="IFavouritesInfo"/> 
public record FavouritesInfo
(
    DateTime AddedAt
) : IFavouritesInfo;