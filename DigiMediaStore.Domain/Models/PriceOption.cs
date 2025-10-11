using System;
using System.Collections.Generic;

namespace DigiMediaStore.Domain.Models;

public partial class PriceOption
{
    public int OptionId { get; set; }

    public int? ContentId { get; set; }

    public decimal Price { get; set; }

    public bool IsRental { get; set; }

    public TimeSpan? RentalPeriod { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public virtual Content? Content { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
