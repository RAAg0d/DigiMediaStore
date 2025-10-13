using System.ComponentModel.DataAnnotations;

namespace DigiMediaStore.Contracts.Order;

/// <summary>
/// Запрос на создание нового заказа
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Required(ErrorMessage = "ID пользователя обязателен")]
    public int UserId { get; set; }

    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    [Required(ErrorMessage = "Сумма заказа обязательна")]
    [Range(0, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public string? Status { get; set; } = "Pending";

    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime? OrderDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Комментарии к заказу
    /// </summary>
    public string? Notes { get; set; }
}
