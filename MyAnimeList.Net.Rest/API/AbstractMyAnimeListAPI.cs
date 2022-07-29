using System;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Text.Json;
using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Net.API.Abstractions.API.Objects.Errors;
using MyAnimeList.Net.API.Abstractions.Requests;
using MyAnimeList.Net.API.Objects.Errors;
using MyAnimeList.Net.Rest.Utility.Properties;
using MyAnimeList.Net.Rest.Utility.Requests;
using Remora.Rest;
using Remora.Rest.Core;
using Remora.Results;

namespace MyAnimeList.Net.Rest.API;

/// <summary>
/// Acts as a base for all REST API instances.
/// </summary>
public abstract class AbstractMyAnimeListAPI 
{
    /// <summary>
    /// Gets the REST HTTP client available to the API instance.
    /// </summary>
    protected RestHttpClient<IMyAnimeListRestError> RestHttpClient { get; }
    
    /// <summary>
    /// Gets the JSON options available to the API instance.
    /// </summary>
    protected JsonSerializerOptions JsonOptions { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractMyAnimeListAPI"/> class.
    /// </summary>
    /// <param name="restHttpClient">The REST HTTP client.</param>
    /// <param name="jsonOptions">The JSON options.</param>
    protected AbstractMyAnimeListAPI(RestHttpClient<IMyAnimeListRestError> restHttpClient, JsonSerializerOptions jsonOptions)
    {
        RestHttpClient = restHttpClient;
        JsonOptions = jsonOptions;
    }
    
    /// <summary>
    /// Converts the requested properties into a <see cref="PropertyNameStore"/>.
    /// </summary>
    /// <param name="requestBuilder">The property request builder.</param>
    /// <typeparam name="TObject">The object to build against.</typeparam>
    /// <returns>Whether the conversion was successful.</returns>
    private protected Result<PropertyNameStore> ConvertPropertyNames<TObject>
    (
       Action<IPropertyRequestBuilder<TObject>>? requestBuilder = default
    )
    {
        var animeRequestBuilder = new PropertyRequestBuilder<TObject>();
        requestBuilder?.Invoke(animeRequestBuilder);
        
        return PropertyNameConverter.ConvertProperties(animeRequestBuilder.Properties, this.JsonOptions);
    }
}