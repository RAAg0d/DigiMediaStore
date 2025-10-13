namespace DigiMediaStore.Contracts.Order;

/// <summary>
/// Ответ с данными заказа
/// </summary>
public class GetOrderResponse
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// Комментарии к заказу
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime? CreatedAt { get; set; }
}
