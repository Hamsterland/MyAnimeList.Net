using System.ComponentModel;
using MyAnimeList.API.Abstractions.API.Objects.Anime;
using MyAnimeList.Rest.Utility.Internal.Converters.Anime;

namespace MyAnimeList.Rest.Utility.Internal.Converters;

public static class ConverterStore
{
    

    private static Dictionary<Type, IConverter> _converters = new()
    {
        { typeof(AiringStatus), new AiringStatusConverter() }
    };
}