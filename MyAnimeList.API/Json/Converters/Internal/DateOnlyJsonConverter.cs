using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyAnimeList.API.Json.Converters.Internal;

/// <inheritdoc/> 
internal class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    /// <inheritdoc/> 
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        DateOnly dateOnly;

        switch (reader.TokenType)
        {
            case JsonTokenType.String:
            {
                var value = reader.GetString();

                if (value is null)
                {
                    throw new JsonException("Failed to deserialize DateOnly from null string.");
                }
                
                if (DateOnly.TryParse(value, out dateOnly))
                {
                    return dateOnly;
                }

                if (value.Length == 4 && !value.Contains('-') && int.TryParse(value, out var year))
                {
                    dateOnly = new DateOnly(year, 1, 1);
                }
                else if (value.Length > 4 && value.Contains('-'))
                {
                    var sections = value.Split('-');
                    
                    if (sections.Length == 3 &&
                        int.TryParse(sections[0], out year) && 
                        int.TryParse(sections[1], out var month) && 
                        int.TryParse(sections[2], out var day))
                    {
                        dateOnly = new DateOnly(year, month, day);
                    }
                    else if (sections.Length == 2 && 
                        int.TryParse(sections[0], out year) && 
                        int.TryParse(sections[1], out month))
                    {
                        dateOnly = new DateOnly(year, month, 0);
                    }
                    else
                    {
                        throw new JsonException($"Failed to deserialize DateOnly from string '{value}'.");
                    }
                }

                return dateOnly;
            }
            default:
            {
                throw new JsonException($"Failed to deserialize DateOnly from token type '{reader.TokenType}'.");
            }
        }
    }

    /// <inheritdoc/> 
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}