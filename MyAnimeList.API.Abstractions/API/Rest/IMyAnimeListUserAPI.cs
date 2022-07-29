using MyAnimeList.API.Abstractions.API.Objects.User;
using MyAnimeList.API.Abstractions.Requests;
using Remora.Results;

namespace MyAnimeList.API.Abstractions.API.Rest;

/// <summary>
/// Represents the MyAnimeList User API.
/// </summary>
public interface IMyAnimeListUserAPI
{
    /// <summary>
    /// Gets the user information of the currently authenticated user.
    /// </summary>
    /// <param name="requestBuilder">The request builder.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>Whether the retrieval was successful.</returns>
    Task<Result<IUser>> GetCurrentUserAsync
    (
        Action<IPropertyRequestBuilder<IUser>>? requestBuilder = null,
        CancellationToken ct = default
    );
    
    /// <summary>
    /// Gets the user information from the given access token.
    /// </summary>
    /// <param name="accessToken">The access token.</param>
    /// <param name="userID">The user ID.</param>
    /// <param name="requestBuilder">The request builder.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>Whether the retrieval was successful.</returns>
    Task<Result<IUser>> GetUserAsync
    (
        string accessToken,
        string userID = "@me",
        Action<IPropertyRequestBuilder<IUser>>? requestBuilder = null,
        CancellationToken ct = default
    );
}