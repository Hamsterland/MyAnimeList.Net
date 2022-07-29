using MyAnimeList.Net.API.Abstractions.API.Objects.Errors;

namespace MyAnimeList.Net.API.Objects.Errors;

/// <inheritdoc cref="IRestError"/> 
public record RestError
(
    string Message,
    string Error
) : IRestError;