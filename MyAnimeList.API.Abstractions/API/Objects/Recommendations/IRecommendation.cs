namespace MyAnimeList.API.Abstractions.API.Objects.Recommendations;

/// <summary>
/// Represents a recommendation for an entry.
/// </summary>
/// <typeparam name="TObject">The type of the recommended entity.</typeparam>
public interface IRecommendation<out TObject>
{
    /// <summary>
    /// Gets the entry node of the recommendation.
    /// </summary>
    TObject Node { get; }
    
    /// <summary>
    /// Gets the number of recommendations for the entry.
    /// </summary>
    int Count { get; }
}