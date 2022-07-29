using System.Text.Json;
using System.Web;
using MyAnimeList.API.Abstractions.API.Objects.OAuth2;
using MyAnimeList.API.Abstractions.API.Rest;
using Remora.Rest;
using Remora.Rest.Core;
using Remora.Results;

namespace MyAnimeList.Rest.API.OAuth2;

/// <inheritdoc cref="IMyAnimeListOAuth2API"/> 
public class MyAnimeListOAuth2API : AbstractMyAnimeListAPI, IMyAnimeListOAuth2API
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyAnimeListOAuth2API"/> class.
    /// </summary>
    public MyAnimeListOAuth2API(IRestHttpClient restHttpClient, JsonSerializerOptions jsonOptions) : base(restHttpClient, jsonOptions)
    {
    }

    /// <inheritdoc/> 
    public Result<string> GetAuthorizationUrl
    (
        string clientId,
        string state,
        string codeChallenge
    )
    {
        var queryParameters = HttpUtility.ParseQueryString(string.Empty);
        
        queryParameters.Add("response_type", "code");
        queryParameters.Add("client_id", clientId);
        queryParameters.Add("state", state);
        queryParameters.Add("code_challenge", codeChallenge);

        return "https://myanimelist.net/v1/oauth2/authoriz?" + queryParameters; 
    }

    /// <inheritdoc/> 
    public Task<Result<IAccessTokenInformation>> GetTokenByAuthorizationCodeAsync
    (
       string clientID, 
       string code,
       string codeVerifier,
       CancellationToken ct = default
    )
    {
        return GetTokenAsync
        (
            "authorization_code",
            clientID,
            code: code,
            codeVerifier: codeVerifier,
            ct: ct
        );
    }

    /// <inheritdoc/> 
    public Task<Result<IAccessTokenInformation>> GetTokenByAuthorizationCodeAsync
    (
        string clientID, 
        string clientSecret,
        string code,
        string codeVerifier,
        CancellationToken ct = default
    )
    {
        return GetTokenAsync
        (
            "authorization_code",
            clientID,
            clientSecret: clientSecret,
            code: code,
            codeVerifier: codeVerifier,
            ct: ct
        );
    }

    /// <inheritdoc/> 
    public async Task<Result<IAccessTokenInformation>> GetTokenByRefreshTokenAsync
    (
        string clientID,
        string refreshToken,
        CancellationToken ct = default
    )
    {
        return await GetTokenAsync
        (
            "refresh_token",
            clientID,
            refreshToken: refreshToken,
            ct: ct
        );
    }

    private Task<Result<IAccessTokenInformation>> GetTokenAsync
    (
        string grantType,
        string clientID,
        Optional<string> clientSecret = default,
        Optional<string> code = default,
        Optional<string> redirectUri = default,
        Optional<string> codeVerifier = default,
        Optional<string> refreshToken = default,
        CancellationToken ct = default
    )
    {
        return this.RestHttpClient.PostAsync<IAccessTokenInformation>
        (
            "https://myanimelist.net/v1/oauth2/token",
            b =>
            {
                var requestBody = new Dictionary<string, string>
                {
                    { "grant_type", grantType },
                    { "client_id", clientID }
                };

                if (clientSecret.HasValue)
                {
                    requestBody.Add("client_secret", clientSecret.Value);
                }

                if (code.HasValue)
                {
                    requestBody.Add("code", code.Value);
                }

                if (redirectUri.HasValue)
                {
                    requestBody.Add("redirect_uri", redirectUri.Value);
                }

                if (codeVerifier.HasValue)
                {
                    requestBody.Add("code_verifier", codeVerifier.Value);
                }

                if (refreshToken.HasValue)
                {
                    requestBody.Add("refresh_token", refreshToken.Value);
                }

                b.With(m => m.Content = new FormUrlEncodedContent(requestBody));
            },
            ct: ct
        );
    }
}