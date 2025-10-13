using System.ComponentModel.DataAnnotations;

namespace DigiMediaStore.Contracts.Genre;

/// <summary>
/// Запрос на обновление жанра
/// </summary>
public class UpdateGenreRequest
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    [Required(ErrorMessage = "ID жанра обязателен")]
    public int GenreId { get; set; }

    /// <summary>
    /// Название жанра
    /// </summary>
    [Required(ErrorMessage = "Название жанра обязательно")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Описание жанра
    /// </summary>
    public string? Description { get; set; }
}
