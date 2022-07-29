using Microsoft.Extensions.DependencyInjection;
using MyAnimeList.Net.Rest.Extensions;
using Remora.Rest.Core;

namespace MyAnimeList.Net.Extensions;

/// <summary>
/// Defines various extension methods to the <see cref="IServiceCollection"/> interface.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the services required to use MyAnimeList's entire API.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="token">The authorization token.</param>
    /// <param name="clientID">The client ID.</param>
    /// <param name="buildClient">An action that enables extra client building operations.</param>
    /// <returns></returns>
    public static IServiceCollection AddMyAnimeList
    (
        this IServiceCollection services,
        Optional<string> token,
        Optional<string> clientID,
        Action<IHttpClientBuilder>? buildClient = null
    )
    {
        return services.AddMyAnimeListRest(token, clientID, buildClient);
    }
}