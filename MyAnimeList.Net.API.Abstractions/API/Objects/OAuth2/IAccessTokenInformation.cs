namespace MyAnimeList.Net.API.Abstractions.API.Objects.OAuth2;

/// <summary>
/// Represents an access token response information.
/// </summary>
public interface IAccessTokenInformation
{
    /// <summary>
    /// Gets the type of the token.
    /// </summary>
    string? TokenType { get; }
    
    /// <summary>
    /// Gets the duration until the token expires.
    /// </summary>
    TimeSpan ExpiresIn { get; }
    
    /// <summary>
    /// Gets the access token.
    /// </summary>
    string? AccessToken { get; }
    
    /// <summary>
    /// Gets the refresh token.
    /// </summary>
    string? RefreshToken { get; }
}