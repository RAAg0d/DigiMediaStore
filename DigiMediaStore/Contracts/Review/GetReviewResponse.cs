namespace DigiMediaStore.Contracts.Review;

/// <summary>
/// Ответ с данными отзыва
/// </summary>
public class GetReviewResponse
{
    /// <summary>
    /// Идентификатор отзыва
    /// </summary>
    public int ReviewId { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Идентификатор контента
    /// </summary>
    public int ContentId { get; set; }

    /// <summary>
    /// Оценка отзыва (от 1 до 5)
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Текст отзыва
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Дата создания отзыва
    /// </summary>
    public DateTime? ReviewDate { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime? CreatedAt { get; set; }
}
