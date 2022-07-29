using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using MyAnimeList.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.Rest.Utility.Internal.Converters.Anime;

/// <inheritdoc/> 
internal class AiringStatusConverter : Converter<AiringStatus>
{
    /// <inheritdoc/> 
    public override AiringStatus ConvertBack(string to)
    {
        return to switch
        {
            "currently_airing" => AiringStatus.CurrentlyAiring,
            "finished_airing" => AiringStatus.FinishedAiring,
            "not_yet_aired" => AiringStatus.NotYetAired,
            _ => throw new ArgumentOutOfRangeException(nameof(to))
        };
    }
}