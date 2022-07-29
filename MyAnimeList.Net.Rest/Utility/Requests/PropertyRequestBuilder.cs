using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using MyAnimeList.Net.API.Abstractions.Requests;
using Remora.Rest.Extensions;

namespace MyAnimeList.Net.Rest.Utility.Requests;

public class PropertyRequestBuilder<TObject> : IPropertyRequestBuilder<TObject>
{
    internal IReadOnlyList<PropertyInfo> Properties => _properties.AsReadOnly();

    public virtual IPropertyRequestBuilder<TObject> WithProperty<TProperty>(Expression<Func<TObject, TProperty>> selector)
    {
        if (selector.Body is not MemberExpression memberExpression)
        {
            throw new ArgumentException("Expression must be a member expression", nameof(selector));
        }

        if (memberExpression.Member is not PropertyInfo property)
        {
            throw new ArgumentException("Expression body must be a property", nameof(selector));
        }

        // The property already exists
        if (_properties.Contains(property))
        {
            return this;
        }
        
        _properties.Add(property);

        return this;
    }

    public IPropertyRequestBuilder<TObject> WithEveryProperty()
    {
        var properties = typeof(TObject).GetPublicProperties();
        _properties.AddRange(properties);
        return this;
    }

    private readonly List<PropertyInfo> _properties = new();
}