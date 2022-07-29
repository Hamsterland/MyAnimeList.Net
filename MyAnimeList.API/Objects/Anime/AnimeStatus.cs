using MyAnimeList.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.API.Objects.Anime;

/// <inheritdoc cref="IAnimeStatus"/> 
public record AnimeStatus
(
    int Watching,
    int Completed,
    int OnHold,
    int Dropped,
    int PlanToWatch
) : IAnimeStatus;