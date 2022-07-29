using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyAnimeList.Net.API.Json.Converters.Internal;

/// <inheritdoc/> 
internal class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    /// <inheritdoc/> 
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        TimeOnly timeOnly;
        
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
            {
                var value = reader.GetString();

                if (value is null)
                {
                    throw new JsonException("Failed to deserialize TimeOnly from null string.");
                }

                if (TimeOnly.TryParse(value, out timeOnly))
                {
                    return timeOnly;
                }
                
                var split = value.Split(':');
                
                if (!(int.TryParse(split[0], out var hours) && hours is > 0 and < 23))
                {
                    throw new JsonException($"Failed to deserialize TimeOnly hours from string '{value}'.");
                }
                
                if (!(int.TryParse(split[1], out var minutes) && minutes is > 0 and < 59))
                {
                    throw new JsonException($"Failed to deserialize TimeOnly minutes from string '{value}'");
                }
                
                timeOnly = new TimeOnly(hours, minutes);
                break;
            }
            default:
            {
                throw new JsonException($"Failed to deserialize TimeOnly from token type '{reader.TokenType}'.");
            }
        }

        return timeOnly;
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.Hour}:{value.Minute}:{value.Second}:{value.Millisecond}");
    }
}