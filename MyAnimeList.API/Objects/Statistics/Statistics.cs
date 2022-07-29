using MyAnimeList.API.Abstractions.API.Objects.Statistics;

namespace MyAnimeList.API.Objects.Statistics;

/// <inheritdoc cref="IStatistics{TStatus}"/> 
public record Statistics<TStatus>
(
    int UsersCount,
    TStatus Status
) : IStatistics<TStatus>;   