using System.ComponentModel.DataAnnotations;

namespace DigiMediaStore.Contracts.Content;

/// <summary>
/// Запрос на обновление контента
/// </summary>
public class UpdateContentRequest
{
    /// <summary>
    /// Идентификатор контента
    /// </summary>
    [Required(ErrorMessage = "ID контента обязателен")]
    public int ContentId { get; set; }

    /// <summary>
    /// Название контента
    /// </summary>
    [Required(ErrorMessage = "Название контента обязательно")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Описание контента
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Идентификатор типа контента
    /// </summary>
    [Required(ErrorMessage = "Тип контента обязателен")]
    public int ContentTypeId { get; set; }

    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Required(ErrorMessage = "Жанр обязателен")]
    public int GenreId { get; set; }

    /// <summary>
    /// Цена контента
    /// </summary>
    [Required(ErrorMessage = "Цена обязательна")]
    [Range(0, double.MaxValue, ErrorMessage = "Цена должна быть положительной")]
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
    /// Статус активности контента
    /// </summary>
    public bool? IsActive { get; set; }
}
