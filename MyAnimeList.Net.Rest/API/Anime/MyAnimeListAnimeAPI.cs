using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Net.API.Abstractions.API.Objects.Errors;
using MyAnimeList.Net.API.Abstractions.API.Objects.Pagination;
using MyAnimeList.Net.API.Abstractions.API.Rest;
using MyAnimeList.Net.API.Abstractions.Requests;
using MyAnimeList.Net.Rest.Extensions.Internal;
using Remora.Rest;
using Remora.Rest.Core;
using Remora.Results;

namespace MyAnimeList.Net.Rest.API.Anime;

/// <inheritdoc cref="Net.API.Abstractions.API.Rest.IMyAnimeListAnimeAPI" /> 
public class MyAnimeListAnimeAPI : AbstractMyAnimeListAPI, IMyAnimeListAnimeAPI
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyAnimeListAnimeAPI"/> class.
    /// </summary>
    /// <param name="restHttpClient">The REST HTTP client.</param>
    /// <param name="jsonOptions">The JSON options.</param>
    public MyAnimeListAnimeAPI(RestHttpClient<IMyAnimeListRestError> restHttpClient, JsonSerializerOptions jsonOptions) : base(restHttpClient, jsonOptions)
    {
    }

    public async Task<Result<IPage<IAnime>>> SearchAnimeAsync
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
    )
    {
        var convertPropertyNames = this.ConvertPropertyNames(requestBuilder);
        if (!convertPropertyNames.IsDefined(out var propertyNameStore))
        {
            return Result<IPage<IAnime>>.FromError(convertPropertyNames);
        }
        
        return await this.RestHttpClient.GetAsync<IPage<IAnime>>
        (
            "anime",
            b =>
            {
                if (query.HasValue)
                {
                    b.AddQueryParameter("q", query.Value);
                }

                if (status.HasValue)
                {
                    b.AddQueryParameter("airing_status", status.Value.ToApiString());
                }
                
                if (broadcastDay.HasValue)
                {
                    b.AddQueryParameter("broadcast_day", broadcastDay.Value.ToString().ToLower());
                }
                
                if (startYear.HasValue)
                {
                    b.AddQueryParameter("start_year", startYear.Value.ToString());
                }
                
                if (startSeason.HasValue)
                {
                    b.AddQueryParameter("start_season", startSeason.Value.ToString().ToLower());
                }
                
                if (mediaType.HasValue)
                {
                    b.AddQueryParameter("media_type", mediaType.Value.ToApiString());
                }
                
                if (sort.HasValue)
                {
                    b.AddQueryParameter("sort", sort.Value.ToApiString());
                }

                b.AddQueryParameter("limit", limit.ToString());
                b.AddQueryParameter("offset", offset.ToString());
                b.AddQueryParameter("fields", propertyNameStore.ToFieldString());
            },
            ct: ct
        );
    }

    /// <inheritdoc/> 
    public async Task<Result<IAnime>> GetAnimeAsync
    (
        int id,
        Action<IPropertyRequestBuilder<IAnime>>? requestBuilder = default,
        CancellationToken ct = default
    )
    {
        var convertPropertyNames = this.ConvertPropertyNames(requestBuilder);
        if (!convertPropertyNames.IsDefined(out var propertyNameStore))
        {
            return Result<IAnime>.FromError(convertPropertyNames);
        }

        return await this.RestHttpClient.GetAsync<IAnime>
        (
            $"anime/{id}",
            b => b.AddQueryParameter("fields", propertyNameStore.ToFieldString()),
            ct: ct
        );
    }

    /// <inheritdoc/> 
    public async Task<Result<IPage<IEpisode>>> GetAnimeEpisodesAsync
    (
        int id,
        bool hasVideo = false,
        int limit = 100,
        int offset = 0,
        CancellationToken ct = default
    )
    {
        return await this.RestHttpClient.GetAsync<IPage<IEpisode>>
        (
            $"anime/{id}/episodes",
            b =>
            {
                b.AddQueryParameter("has_video", hasVideo.ToString());
                b.AddQueryParameter("limit", limit.ToString());
                b.AddQueryParameter("offset", offset.ToString());
            },
            ct: ct
        );
    }
}