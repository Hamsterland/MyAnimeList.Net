using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using MyAnimeList.Net.API.Abstractions.API.Rest;
using MyAnimeList.Net.API.Extensions;
using MyAnimeList.Net.API.Objects.Errors;
using MyAnimeList.Net.Rest.API.Anime;
using MyAnimeList.Net.Rest.API.OAuth2;
using MyAnimeList.Net.Rest.API.User;
using Remora.Rest;
using Remora.Rest.Core;
using Remora.Rest.Extensions;

namespace MyAnimeList.Net.Rest.Extensions;

/// <summary>
/// Defines various extension methods to the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the services required to use MyAnimeList's REST API.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="token">The authorization token.</param>
    /// <param name="clientID">The client ID.</param>
    /// <param name="buildClient">An action that enables extra client building operations.</param>
    /// <returns></returns>
    public static IServiceCollection AddMyAnimeListRest
    (
        this IServiceCollection services,
        Optional<string> token,
        Optional<string> clientID,
        Action<IHttpClientBuilder>? buildClient = null
    )
    {
        services.ConfigureMyAnimeListDataObjectConverters();
        services.AddSingleton<ITokenStore>(_ => new TokenStore(token, clientID));
        
        services.TryAddTransient<IMyAnimeListAnimeAPI>(s => new MyAnimeListAnimeAPI
        (
            s.GetRequiredService<IRestHttpClient>(),
            s.GetRequiredService<IOptionsMonitor<JsonSerializerOptions>>().Get("MyAnimeList")
        ));
        
        services.TryAddTransient<IMyAnimeListOAuth2API>(s => new MyAnimeListOAuth2API
        (
            s.GetRequiredService<IRestHttpClient>(),
            s.GetRequiredService<IOptionsMonitor<JsonSerializerOptions>>().Get("MyAnimeList")
        ));
        
        services.TryAddTransient<IMyAnimeListUserAPI>(s => new MyAnimeListUserAPI
        (
            s.GetRequiredService<IRestHttpClient>(),
            s.GetRequiredService<IOptionsMonitor<JsonSerializerOptions>>().Get("MyAnimeList")
        ));

        var clientBuilder = services
            .AddRestHttpClient<RestError>("MyAnimeList")
            // ReSharper disable once VariableHidesOuterVariable
            .ConfigureHttpClient((services, client) =>
            {

                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                var name = assemblyName.Name ?? "MyAnimeLMyAnimeList.Net.Rest";
                var version = assemblyName.Version ?? new Version(1, 0, 0);

                var tokenStore = services.GetRequiredService<ITokenStore>();

                client.BaseAddress = Constants.BaseURL;
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(name, version.ToString()));

                if (tokenStore.Token.HasValue)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenStore.Token.Value);
                }

                if (tokenStore.ClientID.HasValue)
                {
                    client.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", tokenStore.ClientID.Value);
                }
            });
        
        // Run extra user-defined client building operations.
        buildClient?.Invoke(clientBuilder);
        
        return services;
    }
}