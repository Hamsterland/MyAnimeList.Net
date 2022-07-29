using MyAnimeList.API.Abstractions.API.Objects.Anime;
using MyAnimeList.API.Abstractions.API.Objects.Pagination;
using MyAnimeList.API.Abstractions.Requests;
using Remora.Rest.Core;
using Remora.Results;

namespace MyAnimeList.API.Abstractions.API.Rest;

/// <summary>
/// Represents the MyAnimeList Anime API.
/// </summary>
public interface IMyAnimeListAnimeAPI
{
    /// <summary>
    /// Searches for an anime with the given query parameters.
    /// </summary>
    /// <param name="query">The search query.</param>
    /// <param name="status">The airing status.</param>
    /// <param name="broadcastDay">The broadcast day.</param>
    /// <param name="startYear">The start year.</param>
    /// <param name="startSeason">The start season.</param>
    /// <param name="mediaType">The type of media.</param>
    /// <param name="sort">The sort filter.</param>
    /// <param name="limit">The query limit.</param>
    /// <param name="offset">The query offset.</param>
    /// <param name="requestBuilder">The field request builder.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>Whether the search was successful.</returns>
    Task<Result<IPage<IAnime>>> SearchAnimeAsync
    (
        Optional<string> query = default, 
        Optional<AiringStatus> status = default,
        Optional<DayOfWeek> broadcastDay = default,
        Optional<int> startYear = default, 
        Optional<Season> startSeason = default,
        Optional<MediaType> mediaType = default,
        Optional<AnimeSort> sort = default,
        int limit = 100,
        int offset = 0,
        Action<IPropertyRequestBuilder<IAnime>>? requestBuilder = default,
        CancellationToken ct = default
    );

    /// <summary>
    /// Gets the details of the anime with the specified ID.
    /// </summary>
    /// <param name="id">The anime ID.</param>
    /// <param name="requestBuilder">The field request builder.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>Whether the retrieval was successful.</returns>
    Task<Result<IAnime>> GetAnimeAsync
    (
        int id,
        Action<IPropertyRequestBuilder<IAnime>>? requestBuilder = default,
        CancellationToken ct = default
    );

    /// <summary>
    /// Gets the episodes list of an anime with the specified ID.
    /// </summary>
    /// <param name="id">The anime ID.</param>
    /// <param name="hasVideo">Whether only episodes with at least one video should be returned.</param>
    /// <param name="limit">The query limit.</param>
    /// <param name="offset">The query offset.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>Whether the retrieval was successful.</returns>
    Task<Result<IPage<IEpisode>>> GetAnimeEpisodesAsync
    (
        int id,
        bool hasVideo = false,
        int limit = 100,
        int offset = 0,
        CancellationToken ct = default
    );
}