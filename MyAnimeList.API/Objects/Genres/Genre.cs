using MyAnimeList.API.Abstractions.API.Objects.Genres;

namespace MyAnimeList.API.Objects.Genres;

/// <inheritdoc cref="IGenre"/> 
public record Genre
(
    int ID,
    string Name
) : IGenre;