using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.Net.API.Objects.Anime;

/// <inheritdoc cref="IBroadcastSeason"/> 
public record BroadcastSeason
(
    int Year,
    Season Season
) : IBroadcastSeason;