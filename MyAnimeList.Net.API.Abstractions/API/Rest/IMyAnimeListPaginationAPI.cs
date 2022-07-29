using MyAnimeList.Net.API.Abstractions.API.Objects.Pagination;
using OneOf.Types;

namespace MyAnimeList.Net.API.Abstractions.API.Rest;

/// <summary>
/// Represents the MyAnimeList Pagination API.
/// </summary>
/// <remarks>
/// There is no separate "Pagination API" for the MyAnimeList API. Most API subcategories have search features that
/// return paginated responses. This API is a wrapper around the returned paging information that provides pagination
/// support regardless of the API subcategory.
/// </remarks>
public interface IMyAnimeListPaginationAPI
{
    /// <summary>
    /// Gets the next page of results.
    /// </summary>
    /// <param name="page">The current page.</param>
    /// <typeparam name="TObject">The type of the paginated object.</typeparam>
    /// <returns>The next page.</returns>
    Task<Result<IPage<TObject>>> GetNextPageAsync<TObject>(IPage<TObject> page);
    
    /// <summary>
    /// Gets the previous page of results.
    /// </summary>
    /// <param name="page">The current page.</param>
    /// <typeparam name="TObject">The type of the paginated object.</typeparam>
    /// <returns>The next page.</returns>
    Task<Result<IPage<TObject>>> GetPreviousPageAsync<TObject>(IPage<TObject> page);
}