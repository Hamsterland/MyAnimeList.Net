namespace MyAnimeList.Net.API.Abstractions.API.Objects.Relations;

/// <summary>
/// Represents an entry relation.
/// </summary>
public interface IRelation<out TEntry>
{
    /// <summary>
    /// Gets the entry node of the relation.
    /// </summary>
    TEntry Node { get; }
    
    /// <summary>
    /// Gets the type of the relation.
    /// </summary>
    RelationType Type { get; }
    
    /// <summary>
    /// Gets the type of the relation as a formatted string.
    /// </summary>
    string Formatted { get; }
}