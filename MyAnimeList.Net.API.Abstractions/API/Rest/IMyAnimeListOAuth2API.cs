using System.Threading;
using System.Threading.Tasks;
using MyAnimeList.Net.API.Abstractions.API.Objects.OAuth2;
using Remora.Results;

namespace MyAnimeList.Net.API.Abstractions.API.Rest;

/// <summary>
/// Represents the MyAnimeList OAUth2 API.
/// </summary>
public interface IMyAnimeListOAuth2API
{
    /// <summary>
    /// Generates an application authorization URL.
    /// </summary>
    /// <param name="clientId">The client ID.</param>
    /// <param name="state">The state.</param>
    /// <param name="codeChallenge">The code challenge.</param>
    /// <returns>
    /// The generated URL.
    /// </returns>
    Result<string> GetAuthorizationUrl
    (
        string clientId,
        string state,
        string codeChallenge
    );

    /// <summary>
    /// Gets access and refresh tokens.
    /// </summary>
    /// <param name="clientID">The client ID.</param>
    /// <param name="code">The access code.</param>
    /// <param name="codeVerifier">The code verifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    /// Whether the retrieval was successful.
    /// </returns>
    Task<Result<IAccessTokenInformation>> GetTokenByAuthorizationCodeAsync
    (
        string clientID,
        string code,
        string codeVerifier,
        CancellationToken ct = default
    );

    /// <summary>
    /// Gets access and refresh tokens.
    /// </summary>
    /// <param name="clientID">The client ID.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="code">The access code.</param>
    /// <param name="codeVerifier">The code verifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    /// Whether the retrieval was successful.
    /// </returns>
    Task<Result<IAccessTokenInformation>> GetTokenByAuthorizationCodeAsync
    (
        string clientID,
        string clientSecret,
        string code,
        string codeVerifier,
        CancellationToken ct = default
    );

    /// <summary>
    /// Refreshes access and refresh tokens.
    /// </summary>
    /// <param name="clientID">he client ID.</param>
    /// <param name="refreshToken">The previous refresh token.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    /// Whether the retrieval was successful.
    /// </returns>
    Task<Result<IAccessTokenInformation>> GetTokenByRefreshTokenAsync
    (
        string clientID,
        string refreshToken,
        CancellationToken ct = default
    );
}