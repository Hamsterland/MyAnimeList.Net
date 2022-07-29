using MyAnimeList.Net.API.Abstractions.API.Objects.Recommendations;

namespace MyAnimeList.Net.API.Objects.Recommendations;

/// <inheritdoc cref="IRecommendation{TEntry}"/> 
public record Recommendation<TEntry>
(
    TEntry Node,
    int Count
) : IRecommendation<TEntry>;