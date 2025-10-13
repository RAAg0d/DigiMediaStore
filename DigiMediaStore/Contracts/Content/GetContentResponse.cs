namespace DigiMediaStore.Contracts.Content;

/// <summary>
/// Ответ с данными контента
/// </summary>
public class GetContentResponse
{
    /// <summary>
    /// Идентификатор контента
    /// </summary>
    public int ContentId { get; set; }

    /// <summary>
    /// Название контента
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Описание контента
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Идентификатор типа контента
    /// </summary>
    public int ContentTypeId { get; set; }

    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public int GenreId { get; set; }

    /// <summary>
    /// Цена контента
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Путь к файлу контента
    /// </summary>
    public string? FilePath { get; set; }

    /// <summary>
    /// URL изображения обложки
    /// </summary>
    public string? CoverImageUrl { get; set; }

    /// <summary>
    /// Дата выпуска
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Статус активности контента
    /// </summary>
    public bool? IsActive { get; set; }
}
