using System.Text.Json;
using Remora.Rest.Json.Policies;

namespace MyAnimeList.Net.Rest.Utility.Internal.Converters;

/// <summary>
/// Represents a generic type converter.
/// </summary>
/// <typeparam name="TEnum">The enum type.</typeparam>
public abstract class Converter<TEnum> : IConverter where TEnum : notnull
{
    public JsonNamingPolicy NamingPolicy { get; }
    
    public Converter(JsonNamingPolicy? namingPolicy = default)
    {
        NamingPolicy = namingPolicy ?? new SnakeCaseNamingPolicy();
    }

    public virtual string Convert(TEnum enumValue)
    {
        return NamingPolicy.ConvertName(enumValue.ToString() ?? throw new ArgumentNullException(nameof(enumValue)));
    }
    
    public abstract TEnum ConvertBack(string value);
}

/// <summary>
/// Represents a base converter.
/// </summary>
public interface IConverter
{
}