using MyAnimeList.API.Abstractions.API.Objects.Errors;

namespace MyAnimeList.API.Objects.Errors;

/// <inheritdoc cref="IRestError"/> 
public record RestError
(
    string Message,
    string Error
) : IRestError;