namespace DigiMediaStore.Contracts.User;

/// <summary>
/// Ответ с данными пользователя
/// </summary>
public class GetUserResponse
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Полное имя пользователя
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Дата создания аккаунта
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Статус активности пользователя
    /// </summary>
    public bool? IsActive { get; set; }
}
