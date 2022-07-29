using System.ComponentModel;
using MyAnimeList.Net.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Net.Rest.Utility.Internal.Converters.Anime;

namespace MyAnimeList.Net.Rest.Utility.Internal.Converters;

public static class ConverterStore
{
    

    private static Dictionary<Type, IConverter> _converters = new()
    {
        { typeof(AiringStatus), new AiringStatusConverter() }
    };
}