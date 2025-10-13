namespace DigiMediaStore.Models;

/// <summary>
/// Информация об API
/// </summary>
public class ApiInfo
{
    public string Name { get; set; } = "DigiMediaStore API";
    public string Version { get; set; } = "1.0";
    public string Description { get; set; } = "API для платформы цифрового медийного контента";
    public string Database { get; set; } = "PostgreSQL";
}
