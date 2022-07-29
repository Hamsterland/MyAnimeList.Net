using System;
using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.Net.API.Objects.Anime;

/// <inheritdoc cref="IBroadcastDate"/> 
public record BroadcastDate
(
    DayOfWeek Day,
    TimeOnly? StartTime
) : IBroadcastDate;