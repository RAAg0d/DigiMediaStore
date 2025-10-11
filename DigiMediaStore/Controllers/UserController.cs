using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.Models;
using DigiMediaStore.Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace DigiMediaStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <returns>Список всех пользователей</returns>
    /// <response code="200">Список пользователей успешно получен</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetUserResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        var response = users.Adapt<List<GetUserResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Получить пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Данные пользователя</returns>
    /// <response code="200">Пользователь найден</response>
    /// <response code="404">Пользователь не найден</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetUserResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);
        var response = user.Adapt<GetUserResponse>();
        return Ok(response);
    }

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    /// <param name="request">Данные для создания пользователя</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Пользователь успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var user = request.Adapt<User>();
        await _userService.Create(user);
        return Ok();
    }

    /// <summary>
    /// Обновить данные пользователя
    /// </summary>
    /// <param name="request">Данные для обновления пользователя</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Пользователь успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="404">Пользователь не найден</response>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
    {
        var user = request.Adapt<User>();
        await _userService.Update(user);
        return Ok();
    }

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Результат удаления</returns>
    /// <response code="200">Пользователь успешно удален</response>
    /// <response code="404">Пользователь не найден</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Тестовый эндпоинт для отображения ApiInfo в Swagger
    /// </summary>
    /// <param name="apiInfo">Информация об API</param>
    /// <returns>Полученная информация об API</returns>
    /// <response code="200">Информация успешно получена</response>
    [HttpPost("test-api")]
    [ProducesResponseType(typeof(ApiInfo), 200)]
    public IActionResult TestApi([FromBody] ApiInfo apiInfo)
    {
        // Этот endpoint нужен только для отображения ApiInfo в Swagger
        return Ok(apiInfo);
    }
}
