using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.Net.API.Objects.Anime;

/// <inheritdoc cref="IStudio"/> 
public record Studio
(
    int ID,
    string Name
) : IStudio;