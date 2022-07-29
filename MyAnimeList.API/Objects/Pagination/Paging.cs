using MyAnimeList.API.Abstractions.API.Objects.Pagination;
using Remora.Rest.Core;

namespace MyAnimeList.API.Objects.Pagination;

/// <inheritdoc cref="IPaging"/> 
public record Paging
(
    Optional<string> Next,
    Optional<string> Previous
) : IPaging;