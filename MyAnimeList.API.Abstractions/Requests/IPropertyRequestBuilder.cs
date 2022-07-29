using System.Linq.Expressions;

namespace MyAnimeList.API.Abstractions.Requests;

/// <summary>
/// Describes the builder to specify which properties to return from a MyAnimeList API request.
/// </summary>
/// <typeparam name="TObject"></typeparam>
public interface IPropertyRequestBuilder<TObject>
{
    /// <summary>
    /// Marks a property as being included in the API response.
    /// </summary>
    /// <param name="selector">The property selector.</param>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <returns>The configured <see cref="IPropertyRequestBuilder{TObject}"/> with the added property.</returns>
    IPropertyRequestBuilder<TObject> WithProperty<TProperty>(Expression<Func<TObject, TProperty>> selector);
    
    /// <summary>
    /// Marks all properties of a type as being included in the API response.
    /// </summary>
    /// <returns>The configured <see cref="IPropertyRequestBuilder{TObject}"/> with all added properties of <see cref="TObject"/>.</returns>
    IPropertyRequestBuilder<TObject> WithEveryProperty();
}