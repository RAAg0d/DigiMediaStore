using DigiMediaStore.Domain.Models;
using DigiMediaStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiMediaStore.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)] // Скрываем от Swagger UI
public class HiddenSchemaController : ControllerBase
{
    /// <summary>
    /// Получить все модели для отображения в Swagger Schemas
    /// </summary>
    /// <returns>Объект со всеми моделями системы</returns>
    /// <response code="200">Модели успешно получены</response>
    [HttpGet("all-models")]
    [ProducesResponseType(200)]
    public IActionResult GetAllModels()
    {
        // Этот контроллер нужен только для того, чтобы Swagger увидел все модели
        // и добавил их в раздел Schemas, но сам endpoint скрыт от UI
        var models = new
        {
            User = new User(),
            Content = new Content(),
            ContentType = new ContentType(),
            Genre = new Genre(),
            Order = new Order(),
            Review = new Review(),
            Payment = new Payment(),
            OrderItem = new OrderItem(),
            PriceOption = new PriceOption(),
            DatabaseSchema = new DatabaseSchema()
        };
        
        return Ok(models);
    }
}
