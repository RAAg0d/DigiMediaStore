namespace DigiMediaStore;

/// <summary>
/// Модель медиа-контента
/// </summary>
public class MediaContent
{
    /// <summary>Идентификатор</summary>
    public int Id { get; set; }
    /// <summary>Название</summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>Описание</summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>Тип контента (Movie, Series, Music Video и т.д.)</summary>
    public string Type { get; set; } = string.Empty; // Movie, Series, Music Video, etc.
    /// <summary>Жанр</summary>
    public string Genre { get; set; } = string.Empty;
    /// <summary>Цена покупки</summary>
    public decimal Price { get; set; }
    /// <summary>Цена аренды</summary>
    public decimal RentalPrice { get; set; }
    /// <summary>Длительность в минутах</summary>
    public int Duration { get; set; } // in minutes
    /// <summary>Миниатюра (URL)</summary>
    public string? ThumbnailUrl { get; set; }
    /// <summary>Ссылка на видео (URL)</summary>
    public string? VideoUrl { get; set; }
    /// <summary>Дата релиза</summary>
    public DateTime ReleaseDate { get; set; }
    /// <summary>Доступен ли контент</summary>
    public bool IsAvailable { get; set; } = true;
    /// <summary>Рейтинг</summary>
    public double Rating { get; set; }
    /// <summary>Режиссер</summary>
    public string? Director { get; set; }
    /// <summary>Актеры</summary>
    public List<string> Actors { get; set; } = new();
}
