using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Net.API.Abstractions.API.Objects.Movies;
using MyAnimeList.Net.API.Abstractions.API.Objects.Titles;
using Remora.Rest.Core;

namespace MyAnimeList.Net.API.Objects.Anime;

/// <inheritdoc cref="IEpisode"/>
public record Episode
(
    int ID,
    int Number,
    Optional<string?> Title,
    Optional<ITitle> AlternativeTitles,
    Optional<EpisodeType> Type,
    Optional<string?> Synopsis,
    Optional<DateOnly> AiredDate,
    Optional<TimeSpan> Length,
    Optional<IReadOnlyList<IMovie>> Videos
) : IEpisode;