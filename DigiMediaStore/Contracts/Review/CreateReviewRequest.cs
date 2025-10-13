using System.ComponentModel.DataAnnotations;

namespace DigiMediaStore.Contracts.Review;

/// <summary>
/// Запрос на создание нового отзыва
/// </summary>
public class CreateReviewRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Required(ErrorMessage = "ID пользователя обязателен")]
    public int UserId { get; set; }

    /// <summary>
    /// Идентификатор контента
    /// </summary>
    [Required(ErrorMessage = "ID контента обязателен")]
    public int ContentId { get; set; }

    /// <summary>
    /// Оценка отзыва (от 1 до 5)
    /// </summary>
    [Required(ErrorMessage = "Оценка обязательна")]
    [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
    public int Rating { get; set; }

    /// <summary>
    /// Текст отзыва
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Дата создания отзыва
    /// </summary>
    public DateTime? ReviewDate { get; set; } = DateTime.UtcNow;
}
