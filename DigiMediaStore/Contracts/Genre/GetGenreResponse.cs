namespace DigiMediaStore.Contracts.Genre;

/// <summary>
/// Ответ с данными жанра
/// </summary>
public class GetGenreResponse
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public int GenreId { get; set; }

    /// <summary>
    /// Название жанра
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Описание жанра
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime? CreatedAt { get; set; }
}
