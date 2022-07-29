using MyAnimeList.API.Abstractions.API.Objects.Pagination;

namespace MyAnimeList.API.Objects.Pagination;

/// <inheritdoc cref="IPage{TObject}"/> 
public record Page<TObject>
(
    IReadOnlyList<IEntry<TObject>> Data,
    IPaging Paging
) : IPage<TObject>;