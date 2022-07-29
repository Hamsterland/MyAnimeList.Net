// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Remora.Rest.Json;
//
// namespace MyAnimeList.API.Json.Converters.Internal;
//
// internal class StringUnitTimeSpanConverter : JsonConverter<TimeSpan>
// {
//     public TimeUnit TimeUnit { get; }
//
//     internal StringUnitTimeSpanConverter(TimeUnit timeUnit)
//     {
//         TimeUnit = timeUnit;
//     }
//
//     public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//     {
//         TimeSpan timeSpan;
//
//         switch (reader.TokenType)
//         {
//             case JsonTokenType.String:
//             {
//                 var value = reader.GetString();
//
//                 if (value is null)
//                 {
//                     throw new JsonException("Failed to deserialize TimeSpan from null string.");
//                 }
//                 
//                 var sections = value.Split(':');
//
//                 if (sections.Length == 3 &&
//                     int.TryParse(sections[0], out var hours) &&
//                     int.TryParse(sections[1], out var seconds) &&
//                     int.TryParse(sections[2], out var minutes))
//                 {
//                     
//                 }
//             }
//         }
//     }
//
//     public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
//     {
//         throw new NotImplementedException();
//     }
// }