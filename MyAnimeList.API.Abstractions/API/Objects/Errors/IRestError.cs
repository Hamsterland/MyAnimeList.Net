namespace MyAnimeList.API.Abstractions.API.Objects.Errors;

/// <summary>
/// Represents an error reported by the REST API.
/// </summary>
public interface IRestError
{
    /// <summary>
    /// Gets the error message.
    /// </summary>
    string Message { get; }
    
    /// <summary>
    /// Gets the short error description.
    /// </summary>
    string Error { get; }
}