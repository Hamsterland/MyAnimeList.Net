using MyAnimeList.Net.API.Abstractions.API.Objects.Pagination;
using Remora.Rest.Core;

namespace MyAnimeList.Net.API.Objects.Pagination;

/// <inheritdoc cref="IPaging"/> 
public record Paging
(
    Optional<string> Next,
    Optional<string> Previous
) : IPaging;