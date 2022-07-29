using MyAnimeList.Net.API.Abstractions.API.Objects.Images;

namespace MyAnimeList.Net.API.Objects.Images;

/// <inheritdoc cref="IPicture"/> 
public record Picture
(
    string? Large,
    string Medium
) : IPicture;