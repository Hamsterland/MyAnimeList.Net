namespace MyAnimeList.Net.API.Abstractions.API.Objects.Statistics;

/// <summary>
/// Represents list statistics for an entry.
/// </summary>
public interface IStatistics<out TStatus>
{
    /// <summary>
    /// Gets the number of users who have this entry in their list.
    /// </summary>
    int UsersCount { get; }
    
    /// <summary>
    /// Gets the list status of the entry.
    /// </summary>
    TStatus Status { get; }
}