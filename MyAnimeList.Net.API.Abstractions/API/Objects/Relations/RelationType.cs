namespace MyAnimeList.Net.API.Abstractions.API.Objects.Relations;

/// <summary>
/// Represents the type of a relation.
/// </summary>
public enum RelationType
{
    /// <summary>
    /// The relation is a sequel.
    /// </summary>
    Sequel,
    
    /// <summary>
    /// The relation is a prequel.
    /// </summary>
    Prequel,
    
    /// <summary>
    /// The relation is an alternative setting.
    /// </summary>
    AlternativeSetting,
    
    /// <summary>
    /// The relation is an alternative version.
    /// </summary>
    AlternativeVersion,
    
    /// <summary>
    /// The relation is a side story.
    /// </summary>
    SideStory,
    
    /// <summary>
    /// The relation is a parent story.
    /// </summary>
    ParentStory,
    
    /// <summary>
    /// The relation is a summary.
    /// </summary>
    Summary,
    
    /// <summary>
    /// The relation is a full story.
    /// </summary>
    FullStory,
    
    /// <summary>
    /// The relation is a spin-off.
    /// </summary>
    SpinOff
}