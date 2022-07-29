using MyAnimeList.API.Abstractions.API.Objects.Anime;
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

namespace MyAnimeList.API.Objects.Anime;

/// <inheritdoc cref="IAnime"/> 
public record Anime
(
    int ID,
    string Title,
    Optional<IPicture> MainPicture,
    Optional<ITitle> AlternativeTitles,
    Optional<DateOnly?> StartDate,
    Optional<DateOnly?> EndDate,
    Optional<string?> Synopsis,
    Optional<float?> Mean,
    Optional<int?> Rank,
    Optional<int?> Popularity,
    Optional<int> ListUsersCount,
    Optional<int> ScoringUsersCount,
    Optional<Nsfw?> Nsfw,
    Optional<IReadOnlyList<IGenre>> Genres,
    Optional<DateTime> CreatedAt,
    Optional<DateTime> UpdatedAt,
    Optional<MediaType> MediaType,
    Optional<AiringStatus> AiringStatus,
    Optional<int> EpisodesCount,
    Optional<IBroadcastSeason?> BroadcastSeason,
    Optional<IBroadcastDate?> BroadcastDate,
    Optional<Source> Source,
    Optional<TimeSpan?> AverageEpisodeDuration,
    Optional<ContentRating> ContentRating,
    Optional<IReadOnlyList<IStudio>> Studios,
    Optional<IFavouritesInfo?> FavouritesInfo,
    Optional<IReadOnlyList<IPicture>> Pictures,
    Optional<string?> Background,
    Optional<IReadOnlyList<IRelation<IAnime>>> RelatedAnime,
    Optional<IReadOnlyList<IRelation<object>>> RelatedManga,
    Optional<IReadOnlyList<IRecommendation<IAnime>>> Recommendations,
    Optional<IStatistics<IAnimeStatus>> Statistics,
    Optional<IReadOnlyList<IMovie>> PromotionalVideos
) : IAnime;