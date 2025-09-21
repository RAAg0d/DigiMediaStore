namespace DigiMediaStore.Models;

public class DatabaseSchema
{
    public string DatabaseName { get; set; } = "DigiMediaStore";
    public string Provider { get; set; } = "PostgreSQL";
    public int TableCount { get; set; } = 9;
    public string Version { get; set; } = "1.0";
}
