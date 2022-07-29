using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;

namespace MyAnimeList.Net.Rest.Utility.Internal.Converters.Anime;

/// <inheritdoc/> 
internal class MediaTypeConverter : Converter<MediaType>
{
    /// <inheritdoc/> 
    public override MediaType ConvertBack(string to)
    {
        return to switch
        {
            "unknown" => MediaType.Unknown,
            "tv" => MediaType.Tv,
            "ova" => MediaType.Ova,
            "movie" => MediaType.Movie,
            "special" => MediaType.Special,
            "ona" => MediaType.Ona,
            "music" => MediaType.Music,
            _ => throw new ArgumentOutOfRangeException(nameof(to))
        };
    }
}