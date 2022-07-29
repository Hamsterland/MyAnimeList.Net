using System;
using System.Collections.Specialized;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MyAnimeList.Net.API.Abstractions.API.Objects.User;
using MyAnimeList.Net.API.Abstractions.API.Rest;
using MyAnimeList.Net.API.Abstractions.Requests;
using Remora.Rest;
using Remora.Results;

namespace MyAnimeList.Net.Rest.API.User;

/// <inheritdoc cref="Net.API.Abstractions.API.Rest.IMyAnimeListUserAPI" /> 
public class MyAnimeListUserAPI : AbstractMyAnimeListAPI, IMyAnimeListUserAPI
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyAnimeListUserAPI"/> class.
    /// </summary>
    public MyAnimeListUserAPI(IRestHttpClient restHttpClient, JsonSerializerOptions jsonOptions) : base(restHttpClient, jsonOptions)
    {
    }

    public async Task<Result<IUser>> GetCurrentUserAsync(Action<IPropertyRequestBuilder<IUser>>? requestBuilder = null, CancellationToken ct = default)
    {
        var convertPropertyNames = this.ConvertPropertyNames(requestBuilder);
        if (!convertPropertyNames.IsDefined(out var propertyNameStore))
        {
            return Result<IUser>.FromError(convertPropertyNames);
        }
        
        return await this.RestHttpClient.GetAsync<IUser>
        (
            "users/@me",
            b => b.AddQueryParameter("fields", propertyNameStore.ToFieldString()),
            ct: ct
        );
    }

    /// <inheritdoc/> 
    public async Task<Result<IUser>> GetUserAsync
    (
        string accessToken,
        string userID = "@me", 
        Action<IPropertyRequestBuilder<IUser>>? requestBuilder = null,
        CancellationToken ct = default
    )
    {
        if (userID is not "@me")
        {
            return new NotSupportedError("Only @me is supported for this endpoint.");
        }

        var convertPropertyNames = this.ConvertPropertyNames(requestBuilder);
        if (!convertPropertyNames.IsDefined(out var propertyNameStore))
        {
            return Result<IUser>.FromError(convertPropertyNames);
        }
        
        return await this.RestHttpClient.GetAsync<IUser>
        (
            $"users/{userID}",
            b =>
            {
                b.AddHeader("Authorization", $"Bearer {accessToken}");
                b.AddQueryParameter("fields", propertyNameStore.ToFieldString());
            },
            ct: ct
        );
    }
}