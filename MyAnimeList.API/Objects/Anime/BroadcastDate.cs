using MyAnimeList.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.API.Objects.Anime;

/// <inheritdoc cref="IBroadcastDate"/> 
public record BroadcastDate
(
    DayOfWeek Day,
    TimeOnly? StartTime
) : IBroadcastDate;