using MyAnimeList.Net.API.Abstractions.API.Objects.Movies;

namespace MyAnimeList.Net.API.Objects.Movies;

/// <inheritdoc cref="IMovie"/>
public record Movie
(
    string? Title,
    string? Url,
    string? PlayerUrl,
    string? ThumbnailUrl
) : IMovie;