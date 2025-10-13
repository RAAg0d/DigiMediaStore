using System.ComponentModel.DataAnnotations;

namespace DigiMediaStore.Contracts.Genre;

/// <summary>
/// Запрос на создание нового жанра
/// </summary>
public class CreateGenreRequest
{
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
