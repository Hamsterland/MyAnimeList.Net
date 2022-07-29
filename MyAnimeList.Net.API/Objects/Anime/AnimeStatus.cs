using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.Net.API.Objects.Anime;

/// <inheritdoc cref="IAnimeStatus"/> 
public record AnimeStatus
(
    int Watching,
    int Completed,
    int OnHold,
    int Dropped,
    int PlanToWatch
) : IAnimeStatus;