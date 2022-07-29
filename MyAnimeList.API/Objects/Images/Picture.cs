﻿using MyAnimeList.API.Abstractions.API.Objects.Images;

namespace MyAnimeList.API.Objects.Images;

/// <inheritdoc cref="IPicture"/> 
public record Picture
(
    string? Large,
    string Medium
) : IPicture;