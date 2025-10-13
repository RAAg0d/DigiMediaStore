namespace DigiMediaStore;

/// <summary>
/// Модель медиа-контента
/// </summary>
public class MediaContent
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Movie, Series, Music Video, etc.
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal RentalPrice { get; set; }
    public int Duration { get; set; } // in minutes
    public string? ThumbnailUrl { get; set; }
    public string? VideoUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool IsAvailable { get; set; } = true;
    public double Rating { get; set; }
    public string? Director { get; set; }
    public List<string> Actors { get; set; } = new();
}
