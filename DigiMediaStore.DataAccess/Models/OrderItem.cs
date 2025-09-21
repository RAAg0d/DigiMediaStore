using System;
using System.Collections.Generic;

namespace DigiMediaStore.DataAccess.Models;

public partial class OrderItem
{
    public int ItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ContentId { get; set; }

    public int? PriceOptionId { get; set; }

    public decimal Price { get; set; }

    public DateTime? AccessExpires { get; set; }

    public virtual Content? Content { get; set; }

    public virtual Order? Order { get; set; }

    public virtual PriceOption? PriceOption { get; set; }
}
