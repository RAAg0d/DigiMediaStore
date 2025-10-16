using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.Contracts.Genre;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace DigiMediaStore.Controllers;

/// <summary>
/// Контроллер для управления жанрами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private IRepositoryWrapper _repositoryWrapper;

    /// <summary>
    /// Конструктор контроллера жанров
    /// </summary>
    /// <param name="repositoryWrapper">Обертка репозиториев</param>
    public GenreController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    /// <summary>
    /// Получить все жанры
    /// </summary>
    /// <returns>Список всех жанров</returns>
    /// <response code="200">Список жанров успешно получен</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetGenreResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var genres = await _repositoryWrapper.Genre.FindAll();
        var response = genres.ToList().Adapt<List<GetGenreResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Получить жанр по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор жанра</param>
    /// <returns>Данные жанра</returns>
    /// <response code="200">Жанр найден</response>
    /// <response code="404">Жанр не найден</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetGenreResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var genre = await _repositoryWrapper.Genre.FindByCondition(x => x.GenreId == id);
        var result = genre.FirstOrDefault();
        if (result == null)
            return NotFound();

        var response = result.Adapt<GetGenreResponse>();
        return Ok(response);
    }

    /// <summary>
    /// Создать новый жанр
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Genre
    ///     {
    ///        "name": "Комедия",
    ///        "description": "Жанр комедийных фильмов"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для создания жанра</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Жанр успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateGenreRequest request)
    {
        var genre = request.Adapt<Genre>();
        await _repositoryWrapper.Genre.Create(genre);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Обновить данные жанра
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Genre
    ///     {
    ///        "genreId": 1,
    ///        "name": "Комедия и сатира",
    ///        "description": "Обновленное описание жанра"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для обновления жанра</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Жанр успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="404">Жанр не найден</response>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] UpdateGenreRequest request)
    {
        var genre = request.Adapt<Genre>();
        await _repositoryWrapper.Genre.Update(genre);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Удалить жанр
    /// </summary>
    /// <param name="id">Идентификатор жанра</param>
    /// <returns>Результат удаления</returns>
    /// <response code="200">Жанр успешно удален</response>
    /// <response code="404">Жанр не найден</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _repositoryWrapper.Genre.FindByCondition(x => x.GenreId == id);
        var result = genre.FirstOrDefault();
        if (result == null)
            return NotFound();

        await _repositoryWrapper.Genre.Delete(result);
        await _repositoryWrapper.Save();
        return Ok();
    }
}
