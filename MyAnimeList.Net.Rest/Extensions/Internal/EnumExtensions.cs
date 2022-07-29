using System.Diagnostics;
using System.Security;
using System.Text.Json;
using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Net.API.Abstractions.API.Objects.Ranking;
using Remora.Rest.Json.Policies;

namespace MyAnimeList.Net.Rest.Extensions.Internal;

internal static class EnumExtensions
{
    private static readonly JsonNamingPolicy SnakeCasePolicy = new SnakeCaseNamingPolicy();
    
    internal static string ToApiString(this Enum value) 
    {
        if (value is AnimeSort animeSort)
        {
            return HandleAnimeSort(animeSort);
        }

        if (value is RankingType rankingType)
        {
            return HandleRankingType(rankingType);
        }
        
        return SnakeCasePolicy.ConvertName(value.ToString());
    }

    private static string HandleRankingType(RankingType rankingType)
    {
        return rankingType switch
        {
            RankingType.Popularity => "bypopularity",
            RankingType.Favourite => "favorite",
            _ => SnakeCasePolicy.ConvertName(rankingType.ToString())
        };
    }

    private static string HandleAnimeSort(AnimeSort animeSort)
    {
        return animeSort switch
        {
            AnimeSort.Score => "anime_score",
            AnimeSort.ListUsersCount => "anime_num_list_users",
            AnimeSort.StartDate => "anime_start_date",
            AnimeSort.CreatedAt => animeSort.ToString().ToLower(),
            _ => throw new ArgumentOutOfRangeException(nameof(animeSort), animeSort, null)
        };
    }
}