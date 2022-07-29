using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Net.API.Abstractions.API.Objects.Errors;
using MyAnimeList.Net.API.Abstractions.API.Objects.Favourites;
using MyAnimeList.Net.API.Abstractions.API.Objects.Genres;
using MyAnimeList.Net.API.Abstractions.API.Objects.Images;
using MyAnimeList.Net.API.Abstractions.API.Objects.Movies;
using MyAnimeList.Net.API.Abstractions.API.Objects.OAuth2;
using MyAnimeList.Net.API.Abstractions.API.Objects.Pagination;
using MyAnimeList.Net.API.Abstractions.API.Objects.Rating;
using MyAnimeList.Net.API.Abstractions.API.Objects.Recommendations;
using MyAnimeList.Net.API.Abstractions.API.Objects.Relations;
using MyAnimeList.Net.API.Abstractions.API.Objects.Sources;
using MyAnimeList.Net.API.Abstractions.API.Objects.Statistics;
using MyAnimeList.Net.API.Abstractions.API.Objects.Titles;
using MyAnimeList.Net.API.Abstractions.API.Objects.User;
using MyAnimeList.Net.API.Json.Converters.Internal;
using MyAnimeList.Net.API.Objects.Anime;
using MyAnimeList.Net.API.Objects.Errors;
using MyAnimeList.Net.API.Objects.Favourites;
using MyAnimeList.Net.API.Objects.Genres;
using MyAnimeList.Net.API.Objects.Images;
using MyAnimeList.Net.API.Objects.Movies;
using MyAnimeList.Net.API.Objects.OAuth2;
using MyAnimeList.Net.API.Objects.Pagination;
using MyAnimeList.Net.API.Objects.Recommendations;
using MyAnimeList.Net.API.Objects.Relations;
using MyAnimeList.Net.API.Objects.Statistics;
using MyAnimeList.Net.API.Objects.Titles;
using MyAnimeList.Net.API.Objects.User;
using Remora.Rest.Extensions;
using Remora.Rest.Json;
using Remora.Rest.Json.Policies;

namespace MyAnimeList.Net.API.Extensions;

/// <summary>
/// Defines various extension methods to the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures MyAnimeList-specific.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="optionsName">The name of the serializer options.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection ConfigureMyAnimeListDataObjectConverters(this IServiceCollection services, string optionsName = "MyAnimeList")
    {
        var snakeCase = new SnakeCaseNamingPolicy();
        
        services.TryAddSingleton(snakeCase);
        services.ConfigureRestJsonConverters(optionsName);

        services.Configure<JsonSerializerOptions>
        (
            optionsName,
            options =>
            {
                options.PropertyNamingPolicy = snakeCase;
                options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

                options.AddConverter<DateOnlyJsonConverter>();

                options
                    .AddErrorObjectConverters()
                    .AddAnimeObjectConverters()
                    .AddGenreObjectConverters()
                    .AddImageObjectConverters()
                    .AddTitleObjectConverters()
                    .AddFavouritesObjectConverters()
                    .AddMovieObjectConverters()
                    .AddRecommendationObjectConverters()
                    .AddRelationObjectConverters()
                    .AddStatisticsObjectConverters()
                    .AddPaginationObjectConverters()
                    .AddAccessTokenInformationObjectConverters()
                    .AddUserObjectConverters();
            }
        );
        
        return services;
    }

    private static JsonSerializerOptions AddErrorObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IRestError, RestError>();

        return options;
    }
    
    private static JsonSerializerOptions AddAnimeObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IAnime, Anime>()
            .WithPropertyConverter(a => a.StartDate, new DateOnlyJsonConverter())
            .WithPropertyConverter(a => a.EndDate, new DateOnlyJsonConverter())
            .WithPropertyName(a => a.ContentRating, "rating")
            .WithPropertyConverter(a => a.ContentRating, new OverridableStringEnumConverter<ContentRating>
            (
                new[]
                {
                    new KeyValuePair<ContentRating, string>(ContentRating.Pg13, "pg_13"),
                    new KeyValuePair<ContentRating, string>(ContentRating.Rp, "r+")
                }
            ))
            .WithPropertyName(a => a.AiringStatus, "status")
            .WithPropertyName(a => a.ListUsersCount, "num_list_users")
            .WithPropertyName(a => a.ScoringUsersCount, "num_scoring_users")
            .WithPropertyName(a => a.EpisodesCount, "num_episodes")
            .WithPropertyName(a => a.BroadcastSeason, "start_season")
            .WithPropertyName(a => a.FavouritesInfo, "favorites_info")
            .WithPropertyConverter(a => a.AverageEpisodeDuration, new UnitTimeSpanConverter(TimeUnit.Seconds))
            .WithPropertyConverter(a => a.Source, new OverridableStringEnumConverter<Source>
            (
                new[] {new KeyValuePair<Source, string>(Source.FourKomaManga, "4_koma_manga")}
            ))
            .WithPropertyConverter(a => a.Nsfw, new StringEnumConverter<Nsfw>(new SnakeCaseNamingPolicy()))
            .WithPropertyConverter(a => a.MediaType, new StringEnumConverter<MediaType>(new SnakeCaseNamingPolicy()))
            .WithPropertyConverter(a => a.AiringStatus, new StringEnumConverter<AiringStatus>(new SnakeCaseNamingPolicy()))
            .WithPropertyName(a => a.BroadcastDate, "broadcast");

        options.AddDataObjectConverter<IBroadcastDate, BroadcastDate>()
            .WithPropertyName(b => b.Day, "day_of_the_week")
            .WithPropertyConverter(b => b.Day, new StringEnumConverter<DayOfWeek>())
            .WithPropertyConverter(b => b.StartTime, new TimeOnlyJsonConverter());
        
        options.AddDataObjectConverter<IBroadcastSeason, BroadcastSeason>()
            .WithPropertyConverter(b => b.Season, new StringEnumConverter<Season>());
        
        options.AddDataObjectConverter<IStudio, Studio>();
        
        options.AddDataObjectConverter<IEpisode, Episode>()
            .WithPropertyName(e => e.Number, "episode_number")
            .WithPropertyName(e => e.Length, "duration")
            // .WithPropertyConverter(e => e.Length, new TimeOnlyJsonConverter())
            .WithPropertyConverter(e => e.AiredDate, new DateOnlyJsonConverter());

        
        return options;
    }
    
    private static JsonSerializerOptions AddGenreObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IGenre, Genre>();

        return options;
    }
    
    private static JsonSerializerOptions AddImageObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IPicture, Picture>();

        return options;
    }
    
    private static JsonSerializerOptions AddTitleObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<ITitle, Title>()
            .WithPropertyName(t => t.English, "en")
            .WithPropertyName(t => t.Japanese, "ja");

        return options;
    }
    
    private static JsonSerializerOptions AddFavouritesObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IFavouritesInfo, FavouritesInfo>();

        return options;
    }
    
    private static JsonSerializerOptions AddMovieObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IMovie, Movie>();

        return options;
    }
    
    private static JsonSerializerOptions AddRecommendationObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IRecommendation<IAnime>, Recommendation<IAnime>>()
            .WithPropertyName(r => r.Count, "num_recommendations");

        return options;
    }
    
    private static JsonSerializerOptions AddRelationObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IRelation<IAnime>, Relation<IAnime>>()
            .WithPropertyName(r => r.Type, "relation_type")
            .WithPropertyConverter(r => r.Type, new StringEnumConverter<RelationType>(new SnakeCaseNamingPolicy()))
            .WithPropertyName(r => r.Formatted, "relation_type_formatted");

        return options;
    }
    
    private static JsonSerializerOptions AddStatisticsObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IStatistics<IAnimeStatus>, Statistics<IAnimeStatus>>()
            .WithPropertyName(s => s.UsersCount, "num_list_users");

        options.AddDataObjectConverter<IAnimeStatus, AnimeStatus>();
        
        return options;
    }
    
    private static JsonSerializerOptions AddAccessTokenInformationObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IAccessTokenInformation, AccessTokenInformation>()
            .WithPropertyConverter(t => t.ExpiresIn, new UnitTimeSpanConverter(TimeUnit.Seconds));

        return options;
    }
    
    private static JsonSerializerOptions AddUserObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IUser, User>()
            .WithPropertyName(u => u.PictureUrl, "picture");

        return options;
    }
    
    private static JsonSerializerOptions AddPaginationObjectConverters(this JsonSerializerOptions options)
    {
        options.AddDataObjectConverter<IPaging, Paging>();

        options.AddDataObjectConverter<IPage<IAnime>, Page<IAnime>>();
        options.AddDataObjectConverter<IEntry<IAnime>, Entry<IAnime>>();
        
        options.AddDataObjectConverter<IPage<IEpisode>, Page<IEpisode>>();
        options.AddDataObjectConverter<IEntry<IEpisode>, Entry<IEpisode>>();
        
        return options;
    }
}   