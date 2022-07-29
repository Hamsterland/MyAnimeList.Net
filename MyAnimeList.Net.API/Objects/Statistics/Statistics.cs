using MyAnimeList.Net.API.Abstractions.API.Objects.Statistics;

namespace MyAnimeList.Net.API.Objects.Statistics;

/// <inheritdoc cref="IStatistics{TStatus}"/> 
public record Statistics<TStatus>
(
    int UsersCount,
    TStatus Status
) : IStatistics<TStatus>;   