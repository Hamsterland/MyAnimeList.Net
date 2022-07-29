using System.Text.Json;
using System.Text.Json.Serialization;
using MyAnimeList.API.Abstractions.API.Objects.Rating;
using Remora.Rest.Json;
using Remora.Rest.Json.Policies;

namespace MyAnimeList.API.Json.Converters.Internal;

/// <inheritdoc/> 
internal class OverridableStringEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    private readonly Dictionary<TEnum, string> _enumToNameOverrides = new();
    private readonly Dictionary<string, TEnum> _nameToEnumOverrides = new();
    private readonly StringEnumConverter<TEnum> _stringEnumConverter;

    /// <summary>
    /// Initializes a new instance of the <see cref="OverridableStringEnumConverter{TEnum}"/> class.
    /// </summary>
    /// <param name="overrides">The name conversion overrides.</param>
    /// <param name="namingPolicy">The naming policy.</param>
    public OverridableStringEnumConverter(IEnumerable<KeyValuePair<TEnum, string>> overrides, JsonNamingPolicy? namingPolicy = default)
    {
        namingPolicy ??= new SnakeCaseNamingPolicy();
        
        foreach (var kvp in overrides)
        {
            _enumToNameOverrides.Add(kvp.Key, kvp.Value);
            _nameToEnumOverrides.Add(kvp.Value, kvp.Key);
        }

        _stringEnumConverter = new StringEnumConverter<TEnum>(namingPolicy);
    }

    /// <inheritdoc/> 
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.String)
        {
            throw new JsonException("Invalid type for enum deserialization.");
        }

        var strValue = reader.GetString();
        if (strValue is null)
        {
            throw new JsonException("Invalid value for enum deserialization.");
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (_nameToEnumOverrides.ContainsKey(strValue))
        {
            return _nameToEnumOverrides[strValue];
        }
        
        return _stringEnumConverter.Read(ref reader, typeToConvert, options);
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        if (_enumToNameOverrides.ContainsKey(value))
        {
            writer.WriteStringValue(_enumToNameOverrides[value]);
            return;
        }
        
        _stringEnumConverter.Write(writer, value, options);
    }
}