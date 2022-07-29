using MyAnimeList.API.Abstractions.API.Objects.User;
using Remora.Rest.Core;

namespace MyAnimeList.API.Objects.User;

/// <inheritdoc cref="IUser"/>
public record User
(
    int ID,
    string Name,
    Optional<string> PictureUrl,
    Optional<Gender> Gender,
    Optional<DateOnly> Birthday,
    Optional<string> Location,
    Optional<DateTime> JoinedAt,
    Optional<string> Timezone,
    Optional<bool> IsSupporter,
    Optional<bool> IsOnline,
    Optional<DateTime> LastActivityAt
) : IUser;