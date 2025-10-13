using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace DigiMediaStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private IRepositoryWrapper _repositoryWrapper;
    
    public ReviewController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    /// <summary>
    /// Получить все отзывы
    /// </summary>
    /// <returns>Список всех отзывов</returns>
    /// <response code="200">Список отзывов успешно получен</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<Review>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _repositoryWrapper.Review.FindAll();
        return Ok(reviews.ToList());
    }

    /// <summary>
    /// Получить отзыв по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор отзыва</param>
    /// <returns>Данные отзыва</returns>
    /// <response code="200">Отзыв найден</response>
    /// <response code="404">Отзыв не найден</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Review), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var review = await _repositoryWrapper.Review.FindByCondition(x => x.ReviewId == id);
        var result = review.FirstOrDefault();
        if (result == null)
            return NotFound();
        
        return Ok(result);
    }

    /// <summary>
    /// Получить отзывы по контенту
    /// </summary>
    /// <param name="contentId">Идентификатор контента</param>
    /// <returns>Список отзывов для контента</returns>
    /// <response code="200">Отзывы контента успешно получены</response>
    [HttpGet("content/{contentId}")]
    [ProducesResponseType(typeof(List<Review>), 200)]
    public async Task<IActionResult> GetByContentId(int contentId)
    {
        var reviews = await _repositoryWrapper.Review.FindByCondition(x => x.ContentId == contentId);
        return Ok(reviews.ToList());
    }

    /// <summary>
    /// Получить отзывы пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Список отзывов пользователя</returns>
    /// <response code="200">Отзывы пользователя успешно получены</response>
    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(List<Review>), 200)]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var reviews = await _repositoryWrapper.Review.FindByCondition(x => x.UserId == userId);
        return Ok(reviews.ToList());
    }

    /// <summary>
    /// Создать новый отзыв
    /// </summary>
    /// <param name="review">Данные отзыва</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Отзыв успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Review review)
    {
        await _repositoryWrapper.Review.Create(review);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Обновить данные отзыва
    /// </summary>
    /// <param name="review">Данные отзыва</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Отзыв успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="404">Отзыв не найден</response>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] Review review)
    {
        await _repositoryWrapper.Review.Update(review);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Удалить отзыв
    /// </summary>
    /// <param name="id">Идентификатор отзыва</param>
    /// <returns>Результат удаления</returns>
    /// <response code="200">Отзыв успешно удален</response>
    /// <response code="404">Отзыв не найден</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var review = await _repositoryWrapper.Review.FindByCondition(x => x.ReviewId == id);
        var result = review.FirstOrDefault();
        if (result == null)
            return NotFound();
            
        await _repositoryWrapper.Review.Delete(result);
        await _repositoryWrapper.Save();
        return Ok();
    }
}
