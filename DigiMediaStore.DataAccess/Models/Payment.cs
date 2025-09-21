using System;
using System.Collections.Generic;

namespace DigiMediaStore.DataAccess.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public virtual Order? Order { get; set; }
}
