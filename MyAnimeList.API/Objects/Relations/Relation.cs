using MyAnimeList.API.Abstractions.API.Objects.Relations;

namespace MyAnimeList.API.Objects.Relations;

/// <inheritdoc cref="IRelation{TEntry}"/>   
public record Relation<TEntry> 
(
    TEntry Node,
    RelationType Type,
    string Formatted
) : IRelation<TEntry>;