using System;
using System.Collections.Generic;

namespace DigiMediaStore.Domain.Models;

public partial class ContentType
{
    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}
