using System;
using System.Collections.Generic;

namespace DigiMediaStore.Domain.Models;

public partial class Content
{
    public int ContentId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public TimeSpan? Duration { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? TypeId { get; set; }

    public decimal BasePrice { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<PriceOption> PriceOptions { get; set; } = new List<PriceOption>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ContentType? Type { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
