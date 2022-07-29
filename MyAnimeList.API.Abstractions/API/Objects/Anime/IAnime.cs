using MyAnimeList.API.Abstractions.API.Objects.Favourites;
using MyAnimeList.API.Abstractions.API.Objects.Genres;
using MyAnimeList.API.Abstractions.API.Objects.Images;
using MyAnimeList.API.Abstractions.API.Objects.Movies;
using MyAnimeList.API.Abstractions.API.Objects.Rating;
using MyAnimeList.API.Abstractions.API.Objects.Recommendations;
using MyAnimeList.API.Abstractions.API.Objects.Relations;
using MyAnimeList.API.Abstractions.API.Objects.Sources;
using MyAnimeList.API.Abstractions.API.Objects.Statistics;
using MyAnimeList.API.Abstractions.API.Objects.Titles;
using Remora.Rest.Core;

namespace MyAnimeList.API.Abstractions.API.Objects.Anime;

/// <summary>
/// Represents an anime.
/// </summary>
public interface IAnime
{
    /// <summary>
    /// Gets the ID of the anime.
    /// </summary>
    int ID { get; }
    
    /// <summary>
    /// Gets the title of the anime.
    /// </summary>
    string Title { get; }
    
    /// <summary>
    /// Gets the main picture of the anime.
    /// </summary>
    Optional<IPicture> MainPicture { get; }
    
    /// <summary>
    /// Gets the alternative titles of the anime.
    /// </summary>
    Optional<ITitle> AlternativeTitles { get; }
    
    /// <summary>
    /// Gets the start date of the anime.
    /// </summary>
    Optional<DateOnly?> StartDate { get; }
    
    /// <summary>
    /// Gets the end date of the anime.
    /// </summary>
    Optional<DateOnly?> EndDate { get; }
    
    /// <summary>
    /// Gets the synopsis of the anime.
    /// </summary>
    Optional<string?> Synopsis { get; }
    
    /// <summary>
    /// Gets the mean score of the anime.
    /// </summary>
    Optional<float?> Mean { get; }
    
    /// <summary>
    /// Gets the rank of the anime.
    /// </summary>
    Optional<int?> Rank { get; }
    
    /// <summary>
    /// Gets the popularity of the anime.
    /// </summary>
    Optional<int?> Popularity { get; }
    
    /// <summary>
    /// Gets the number of users who have this anime on their list.
    /// </summary>
    Optional<int> ListUsersCount { get; }
    
    /// <summary>
    /// Gets the number of users who have scored this anime.
    /// </summary>
    Optional<int> ScoringUsersCount { get; }
    
    /// <summary>
    /// Gets the NSFW status of the anime.
    /// </summary>
    Optional<Nsfw?> Nsfw { get; }
    
    /// <summary>
    /// Gets the genres of the anime.
    /// </summary>
    Optional<IReadOnlyList<IGenre>> Genres { get; }
    
    /// <summary>
    /// Gets the internal date of when this anime was inserted into the MyAnimeList database.
    /// </summary>
    Optional<DateTime> CreatedAt { get; }
    
    /// <summary>
    /// Gets the internal date of when this anime was last updated in the MyAnimeList database.
    /// </summary>
    Optional<DateTime> UpdatedAt { get; }
    
    /// <summary>
    /// Gets the media type of the anime.
    /// </summary>
    Optional<MediaType> MediaType { get; }
    
    /// <summary>
    /// Gets the airing status of the anime.
    /// </summary>
    Optional<AiringStatus> AiringStatus { get; }
    
    /// <summary>
    /// Gets the number of episodes of the anime.
    /// </summary>
    Optional<int> EpisodesCount { get; }
    
    /// <summary>
    /// Gets the season in which the anime was broadcast.
    /// </summary>
    Optional<IBroadcastSeason?> BroadcastSeason { get; }
    
    /// <summary>
    /// Gets the recurring date in which the anime was broadcast.
    /// </summary>
    Optional<IBroadcastDate?> BroadcastDate { get; }
    
    /// <summary>
    /// Gets the source type of the anime.
    /// </summary>
    Optional<Source> Source { get; }
    
    /// <summary>
    /// Gets the average episode duration of the anime. 
    /// </summary>
    Optional<TimeSpan?> AverageEpisodeDuration { get; }
    
    /// <summary>
    /// Gets the content rating of the anime.
    /// </summary>
    Optional<ContentRating> ContentRating { get; }
    
    /// <summary>
    /// Gets the studios that produced the anime.
    /// </summary>
    Optional<IReadOnlyList<IStudio>> Studios { get; }
    
    /// <summary>
    /// Gets the favourites information of this anime for the authenticated user.
    /// </summary>
    Optional<IFavouritesInfo?> FavouritesInfo { get; }
    
    /// <summary>
    /// Gets the pictures of the anime.
    /// </summary>
    Optional<IReadOnlyList<IPicture>> Pictures { get; }
    
    /// <summary>
    /// Gets the background information of the anime.
    /// </summary>
    Optional<string?> Background { get; }
    
    /// <summary>
    /// Gets the related anime for the anime.
    /// </summary>
    Optional<IReadOnlyList<IRelation<IAnime>>> RelatedAnime { get; }
    
    /// <summary>
    /// Gets the related manga for the anime.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    Optional<IReadOnlyList<IRelation<object>>> RelatedManga => throw new NotImplementedException();
    
    /// <summary>
    /// Gets the recommendations for the anime.
    /// </summary>
    Optional<IReadOnlyList<IRecommendation<IAnime>>> Recommendations { get; }
    
    /// <summary>
    /// Gets the statistics of the anime.
    /// </summary>
    Optional<IStatistics<IAnimeStatus>> Statistics { get; }
    
    /// <summary>
    /// Gets the promotional videos of the anime.
    /// </summary>
    Optional<IReadOnlyList<IMovie>> PromotionalVideos { get; }
}