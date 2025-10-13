using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.Contracts.Content;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace DigiMediaStore.Controllers;

/// <summary>
/// Контроллер для управления контентом
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    private IRepositoryWrapper _repositoryWrapper;
    
    /// <summary>
    /// Конструктор контроллера контента
    /// </summary>
    /// <param name="repositoryWrapper">Обертка репозиториев</param>
    public ContentController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    /// <summary>
    /// Получить весь контент
    /// </summary>
    /// <returns>Список всего контента</returns>
    /// <response code="200">Список контента успешно получен</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetContentResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var content = await _repositoryWrapper.Content.FindAll();
        var response = content.ToList().Adapt<List<GetContentResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Получить контент по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор контента</param>
    /// <returns>Данные контента</returns>
    /// <response code="200">Контент найден</response>
    /// <response code="404">Контент не найден</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetContentResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var content = await _repositoryWrapper.Content.FindByCondition(x => x.ContentId == id);
        var result = content.FirstOrDefault();
        if (result == null)
            return NotFound();
        
        var response = result.Adapt<GetContentResponse>();
        return Ok(response);
    }

    /// <summary>
    /// Создать новый контент
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Content
    ///     {
    ///        "title": "Новый фильм",
    ///        "description": "Описание фильма",
    ///        "contentTypeId": 1,
    ///        "genreId": 1,
    ///        "price": 299.99,
    ///        "filePath": "/movies/new_movie.mp4",
    ///        "coverImageUrl": "https://example.com/cover.jpg",
    ///        "releaseDate": "2024-01-01T00:00:00Z",
    ///        "isActive": true
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для создания контента</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Контент успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateContentRequest request)
    {
        var content = request.Adapt<Content>();
        await _repositoryWrapper.Content.Create(content);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Обновить данные контента
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Content
    ///     {
    ///        "contentId": 1,
    ///        "title": "Обновленный фильм",
    ///        "description": "Новое описание фильма",
    ///        "contentTypeId": 1,
    ///        "genreId": 2,
    ///        "price": 399.99,
    ///        "filePath": "/movies/updated_movie.mp4",
    ///        "coverImageUrl": "https://example.com/new_cover.jpg",
    ///        "releaseDate": "2024-02-01T00:00:00Z",
    ///        "isActive": true
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для обновления контента</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Контент успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="404">Контент не найден</response>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] UpdateContentRequest request)
    {
        var content = request.Adapt<Content>();
        await _repositoryWrapper.Content.Update(content);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Удалить контент
    /// </summary>
    /// <param name="id">Идентификатор контента</param>
    /// <returns>Результат удаления</returns>
    /// <response code="200">Контент успешно удален</response>
    /// <response code="404">Контент не найден</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var content = await _repositoryWrapper.Content.FindByCondition(x => x.ContentId == id);
        var result = content.FirstOrDefault();
        if (result == null)
            return NotFound();
            
        await _repositoryWrapper.Content.Delete(result);
        await _repositoryWrapper.Save();
        return Ok();
    }
}
