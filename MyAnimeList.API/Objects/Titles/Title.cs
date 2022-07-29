using MyAnimeList.API.Abstractions.API.Objects.Titles;
using Remora.Rest.Core;

namespace MyAnimeList.API.Objects.Titles;

/// <inheritdoc cref="ITitle"/>
public record Title
(
    Optional<IReadOnlyList<string?>> Synonyms,
    Optional<string?> English,
    Optional<string?> Japanese
) : ITitle;