using MyAnimeList.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.API.Objects.Anime;

/// <inheritdoc cref="IStudio"/> 
public record Studio
(
    int ID,
    string Name
) : IStudio;