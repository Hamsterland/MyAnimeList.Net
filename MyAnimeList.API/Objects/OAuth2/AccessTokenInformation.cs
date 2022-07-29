using MyAnimeList.API.Abstractions.API.Objects.OAuth2;

namespace MyAnimeList.API.Objects.OAuth2;

/// <inheritdoc cref="IAccessTokenInformation"/>
public record AccessTokenInformation
(
    string? TokenType,
    TimeSpan ExpiresIn,
    string? AccessToken,
    string? RefreshToken
) : IAccessTokenInformation;