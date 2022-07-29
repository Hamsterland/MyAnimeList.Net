using MyAnimeList.API.Abstractions.API.Objects.Movies;

namespace MyAnimeList.API.Objects.Movies;

/// <inheritdoc cref="IMovie"/>
public record Movie
(
    string? Title,
    string? Url,
    string? PlayerUrl,
    string? ThumbnailUrl
) : IMovie;