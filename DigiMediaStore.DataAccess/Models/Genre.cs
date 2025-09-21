using System;
using System.Collections.Generic;

namespace DigiMediaStore.DataAccess.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}
