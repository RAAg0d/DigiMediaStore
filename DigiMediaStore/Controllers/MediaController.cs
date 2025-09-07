using Microsoft.AspNetCore.Mvc;

namespace DigiMediaStore.Controllers;

[ApiController]
[Route("[controller]")]
public class MediaController : ControllerBase
{
    private static List<string> _mediaTitles = new()
    {   
        "Inception", "Stranger Things", "Bohemian Rhapsody", "The Matrix", "Breaking Bad", 
        "Game of Thrones", "Thriller", "Interstellar", "The Witcher", "Shape of You"
    };
    
    [HttpGet]
    public IActionResult GetAll(int? sortStrategy)
    {
        if (sortStrategy is null)
        {
            return Ok(_mediaTitles);
        }
        else if (sortStrategy == 1)
        {
            var sorted = new List<string>(_mediaTitles);
            sorted.Sort();
            return Ok(sorted);
        }
        else if (sortStrategy == -1)
        {
            var sorted = new List<string>(_mediaTitles);
            sorted.Sort();
            sorted.Reverse();
            return Ok(sorted);
        }
        
        return BadRequest("Некорректное значение параметра sortStrategy");
    }

    [HttpGet("{index}")]
    public IActionResult GetByIndex(int? index)
    {
        if (index is null || index < 0 || index >= _mediaTitles.Count)
        {
            return BadRequest("Incorrect value param index");
        }

        return Ok(_mediaTitles[index.Value]);
    }

    [HttpGet("find-by-name")]
    public IActionResult GetCountByName(string? name)
    {
        var count = 0;
        
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Incorrect value param name");
        }

        foreach (var title in _mediaTitles)
        {
            if (title == name)
            {
                count++;
            }
        }
        return Ok(count);
    }

    [HttpPost]
    public IActionResult Add(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Incorrect value param name");
        }
        
        _mediaTitles.Add(name);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(int? index, string? name)
    {
        if (index is null || string.IsNullOrEmpty(name) || index < 0 || index >= _mediaTitles.Count)
        {
            return BadRequest("Incorrect value param name or index");
        }
        
        _mediaTitles[index.Value] = name;
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int? index)
    {
        if (index is null || index < 0 || index >= _mediaTitles.Count)
        {
            return BadRequest("Incorrect value param index");
        }

        _mediaTitles.RemoveAt(index.Value);
        return Ok();
    }
}
