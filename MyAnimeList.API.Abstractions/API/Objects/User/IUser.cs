using Remora.Rest.Core;

namespace MyAnimeList.API.Abstractions.API.Objects.User;

/// <summary>
/// Represents a user's account.
/// </summary>
public interface IUser
{
    /// <summary>
    /// Gets the user ID.
    /// </summary>
    int ID { get; }
    
    /// <summary>
    /// Gets the name of the user.
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Gets the URL of the user's avatar.
    /// </summary>
    Optional<string> PictureUrl { get; }
    
    /// <summary>
    /// Gets the gender of the user.
    /// </summary>
    Optional<Gender> Gender { get; }
    
    /// <summary>
    /// Gets the birthday of the user.
    /// </summary>
    Optional<DateOnly> Birthday { get; }
    
    /// <summary>
    /// Gets the location of the user.
    /// </summary>
    Optional<string> Location { get; }
    
    /// <summary>
    /// Gets the date of registration of the user.
    /// </summary>
    Optional<DateTime> JoinedAt { get; }
    
    /// <summary>
    /// Gets the timezone of the user.
    /// </summary>
    Optional<string> Timezone { get; }
    
    /// <summary>
    /// Gets whether the user is a MAL Supporter or not.
    /// </summary>
    Optional<bool> IsSupporter { get; }
    
    /// <summary>
    /// Gets whether the user is online or not.
    /// </summary>
    Optional<bool> IsOnline { get; }
    
    /// <summary>
    /// Gets the date of the last activity of the user.
    /// </summary>
    Optional<DateTime> LastActivityAt { get; }
}