namespace MyAnimeList.API.Abstractions.API.Objects.Sources;

/// <summary>
/// Represents the type of source media.
/// </summary>
public enum Source
{
    /// <summary>
    /// Other sources.
    /// </summary>
    Other,
    
    /// <summary>
    /// The source is original.
    /// </summary>
    Original,
    
    /// <summary>
    /// The source is a manga.
    /// </summary>
    Manga,
    
    /// <summary>
    /// The source is a 4-Koma manga.
    /// </summary>
    FourKomaManga,
    
    /// <summary>
    /// The source is a web manga.
    /// </summary>
    WebManga,
    
    /// <summary>
    /// The source is a digital manga.
    /// </summary>
    DigitalManga,
    
    /// <summary>
    /// The source is a novel.
    /// </summary>
    Novel,
    
    /// <summary>
    /// The source is a light novel.
    /// </summary>
    LightNovel,
    
    /// <summary>
    /// The source is a visual novel.
    /// </summary>
    VisualNovel,
    
    /// <summary>
    /// The source is a game.
    /// </summary>
    Game,
    
    /// <summary>
    /// The source is a card game.
    /// </summary>
    CardGame,
    
    /// <summary>
    /// The source is a book.
    /// </summary>
    Book,
    
    /// <summary>
    /// The source is a picture book.
    /// </summary>
    PictureBook,
    
    /// <summary>
    /// The source is a radio broadcast.
    /// </summary>
    Radio,
    
    /// <summary>
    /// The source is a music song.
    /// </summary>
    Music
}