using Remora.Rest.Core;

namespace MyAnimeList.Net.Rest;

/// <summary>
/// Represents a storage class for a single authorization token and client ID.
/// </summary>
public interface ITokenStore
{
    /// <summary>
    /// Gets the token.
    /// </summary>
    Optional<string> Token { get; }
    
    /// <summary>
    /// Gets the client ID.
    /// </summary>
    Optional<string> ClientID { get; }
}

/// <inheritdoc/> 
public class TokenStore : ITokenStore
{
    /// <inheritdoc/> 
    public Optional<string> Token { get; }

    /// <inheritdoc/> 
    public Optional<string> ClientID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenStore"/> class.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <param name="client">The client ID.s</param>
    public TokenStore(Optional<string> token, Optional<string> client)
    {
        Token = token;
        ClientID = client;
    }
}