using MyAnimeList.API.Abstractions.API.Objects.Pagination;
using Remora.Rest.Core;

namespace MyAnimeList.API.Objects.Pagination;

/// <inheritdoc cref="IEntry{TObject}"/> 
public record Entry<TObject>
(
    TObject Node,
    Optional<object> Rank
) : IEntry<TObject>;