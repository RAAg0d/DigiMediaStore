using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.Contracts.Review;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace DigiMediaStore.Controllers;

/// <summary>
/// Контроллер для управления отзывами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private IRepositoryWrapper _repositoryWrapper;
    
    /// <summary>
    /// Конструктор контроллера отзывов
    /// </summary>
    /// <param name="repositoryWrapper">Обертка репозиториев</param>
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
    [ProducesResponseType(typeof(List<GetReviewResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _repositoryWrapper.Review.FindAll();
        var response = reviews.ToList().Adapt<List<GetReviewResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Получить отзыв по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор отзыва</param>
    /// <returns>Данные отзыва</returns>
    /// <response code="200">Отзыв найден</response>
    /// <response code="404">Отзыв не найден</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetReviewResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var review = await _repositoryWrapper.Review.FindByCondition(x => x.ReviewId == id);
        var result = review.FirstOrDefault();
        if (result == null)
            return NotFound();
        
        var response = result.Adapt<GetReviewResponse>();
        return Ok(response);
    }

    /// <summary>
    /// Получить отзывы по контенту
    /// </summary>
    /// <param name="contentId">Идентификатор контента</param>
    /// <returns>Список отзывов для контента</returns>
    /// <response code="200">Отзывы контента успешно получены</response>
    [HttpGet("content/{contentId}")]
    [ProducesResponseType(typeof(List<GetReviewResponse>), 200)]
    public async Task<IActionResult> GetByContentId(int contentId)
    {
        var reviews = await _repositoryWrapper.Review.FindByCondition(x => x.ContentId == contentId);
        var response = reviews.ToList().Adapt<List<GetReviewResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Получить отзывы пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Список отзывов пользователя</returns>
    /// <response code="200">Отзывы пользователя успешно получены</response>
    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(List<GetReviewResponse>), 200)]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var reviews = await _repositoryWrapper.Review.FindByCondition(x => x.UserId == userId);
        var response = reviews.ToList().Adapt<List<GetReviewResponse>>();
        return Ok(response);
    }

    /// <summary>
    /// Создать новый отзыв
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Review
    ///     {
    ///        "userId": 1,
    ///        "contentId": 1,
    ///        "rating": 5,
    ///        "comment": "Отличный фильм!",
    ///        "reviewDate": "2024-01-15T12:00:00Z"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для создания отзыва</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Отзыв успешно создан</response>
    /// <response code="400">Некорректные данные запроса</response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
    {
        var review = request.Adapt<Review>();
        await _repositoryWrapper.Review.Create(review);
        await _repositoryWrapper.Save();
        return Ok();
    }

    /// <summary>
    /// Обновить данные отзыва
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Review
    ///     {
    ///        "reviewId": 1,
    ///        "userId": 1,
    ///        "contentId": 1,
    ///        "rating": 4,
    ///        "comment": "Обновленный отзыв",
    ///        "reviewDate": "2024-01-16T12:00:00Z"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">Данные для обновления отзыва</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Отзыв успешно обновлен</response>
    /// <response code="400">Некорректные данные запроса</response>
    /// <response code="404">Отзыв не найден</response>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] UpdateReviewRequest request)
    {
        var review = request.Adapt<Review>();
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
