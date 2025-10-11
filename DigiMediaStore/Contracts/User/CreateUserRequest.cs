using System.ComponentModel.DataAnnotations;

namespace DigiMediaStore.Contracts.User;

/// <summary>
/// Запрос на создание нового пользователя
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// Email пользователя
    /// </summary>
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Хеш пароля пользователя
    /// </summary>
    [Required(ErrorMessage = "Пароль обязателен")]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Полное имя пользователя
    /// </summary>
    [Required(ErrorMessage = "Полное имя обязательно")]
    public string FullName { get; set; } = string.Empty;
}
