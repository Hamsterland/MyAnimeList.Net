using MyAnimeList.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.API.Objects.Anime;

/// <inheritdoc cref="IBroadcastSeason"/> 
public record BroadcastSeason
(
    int Year,
    Season Season
) : IBroadcastSeason;