namespace MyAnimeList.Net.API.Abstractions.API.Objects.Errors;

/// <summary>
/// Represents an error reported by the REST API.
/// </summary>
public interface IMyAnimeListRestError
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