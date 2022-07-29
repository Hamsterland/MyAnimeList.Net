using MyAnimeList.Net.API.Abstractions.API.Objects.Genres;

namespace MyAnimeList.Net.API.Objects.Genres;

/// <inheritdoc cref="IGenre"/> 
public record Genre
(
    int ID,
    string Name
) : IGenre;