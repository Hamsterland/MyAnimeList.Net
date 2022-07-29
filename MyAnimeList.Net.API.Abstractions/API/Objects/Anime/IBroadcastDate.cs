using System;

namespace MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents a broadcast date.
/// </summary>
public interface IBroadcastDate
{
    /// <summary>
    /// Gets the broadcast day.
    /// </summary>
    DayOfWeek Day { get; }
    
    /// <summary>
    /// Gets the time of broadcast on that day.
    /// </summary>
    TimeOnly? StartTime { get; }
}