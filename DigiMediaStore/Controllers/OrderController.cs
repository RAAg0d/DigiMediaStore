using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.Contracts.Order;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace DigiMediaStore.Controllers;

/// <summary>
/// Контроллер для управления заказами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private IRepositoryWrapper _repositoryWrapper;
    
    /// <summary>
    /// Конструктор контроллера заказов
    /// </summary>
    /// <param name="repositoryWrapper">Обертка репозиториев</param>
    public OrderController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    /// <summary>
    /// Получить все заказы
    /// </summary>
    /// <returns>Список всех заказов</returns>
    /// <response code="200">Список заказов успешно получен</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetOrderResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _repositoryWrapper.Order.FindAll();
        var response = orders.ToList().Adapt<List<GetOrderResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Получить заказ по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns>Данные заказа</returns>
    /// <response code="200">Заказ найден</response>
    /// <response code="404">Заказ не найден</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetOrderResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _repositoryWrapper.Order.FindByCondition(x => x.OrderId == id);
        var result = order.FirstOrDefault();
        if (result == null)
            return NotFound();
        
        var response = result.Adapt<GetOrderResponse>();
        return Ok(response);
    }

    /// <summary>
    /// Получить заказы пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Список заказов пользователя</returns>
    /// <response code="200">Заказы пользователя успешно получены</response>
    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(List<GetOrderResponse>), 200)]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var orders = await _repositoryWrapper.Order.FindByCondition(x => x.UserId == userId);
        var response = orders.ToList().Adapt<List<GetOrderResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Создать новый заказ
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Order
    ///     {
    ///        "userId": 1,
    ///        "totalAmount": 599.98,
    ///        "status": "Pending",
    ///        "orderDate": "2024-01-15T10:30:00Z",
    ///        "notes": "Срочный заказ"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для создания заказа</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Заказ успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var order = request.Adapt<Order>();
        await _repositoryWrapper.Order.Create(order);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Обновить данные заказа
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Order
    ///     {
    ///        "orderId": 1,
    ///        "userId": 1,
    ///        "totalAmount": 699.99,
    ///        "status": "Completed",
    ///        "orderDate": "2024-01-15T10:30:00Z",
    ///        "notes": "Заказ выполнен"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для обновления заказа</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Заказ успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="404">Заказ не найден</response>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request)
    {
        var order = request.Adapt<Order>();
        await _repositoryWrapper.Order.Update(order);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Удалить заказ
    /// </summary>
    /// <param name="id">Идентификатор заказа</param>
    /// <returns>Результат удаления</returns>
    /// <response code="200">Заказ успешно удален</response>
    /// <response code="404">Заказ не найден</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _repositoryWrapper.Order.FindByCondition(x => x.OrderId == id);
        var result = order.FirstOrDefault();
        if (result == null)
            return NotFound();
            
        await _repositoryWrapper.Order.Delete(result);
        await _repositoryWrapper.Save();
        return Ok();
    }
}
