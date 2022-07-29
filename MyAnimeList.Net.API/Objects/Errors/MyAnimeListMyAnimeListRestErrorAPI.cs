using MyAnimeList.Net.API.Abstractions.API.Objects.Errors;

namespace MyAnimeList.Net.API.Objects.Errors;

/// <inheritdoc cref="IMyAnimeListRestError"/> 
public record MyAnimeListRestError
(
    string Message,
    string Error
) : IMyAnimeListRestError;