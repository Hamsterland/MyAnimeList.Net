namespace MyAnimeList.Rest;

/// <summary>
/// Holds various constants.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Gets the base API URL.
    /// </summary>
    public static Uri BaseURL { get; } = new("https://api.myanimelist.net/v3/");
}