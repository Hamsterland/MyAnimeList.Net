using MyAnimeList.API.Abstractions.API.Objects.Recommendations;

namespace MyAnimeList.API.Objects.Recommendations;

/// <inheritdoc cref="IRecommendation{TEntry}"/> 
public record Recommendation<TEntry>
(
    TEntry Node,
    int Count
) : IRecommendation<TEntry>;