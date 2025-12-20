using Microsoft.AspNetCore.Mvc;
using Library.Infrastruct.Services;

// Аліаси, щоб не було плутанини між REST.Models і Infrastruct.Models
using DbAuthor = Library.Infrastruct.Models.AuthorModel;
using ApiAuthor = Library.REST.Models.AuthorModel;
using ApiCreateAuthor = Library.REST.Models.CreateAuthorModel;

namespace Library.REST.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ICrudServiceAsync<DbAuthor> _authors;

    public AuthorsController(ICrudServiceAsync<DbAuthor> authors)
    {
        _authors = authors;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApiAuthor>>> GetAll()
    {
        var items = await _authors.ReadAllAsync();
        return Ok(items.Select(a => new ApiAuthor { Id = a.Id, Name = a.Name }));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiAuthor>> GetById(int id)
    {
        var author = await _authors.ReadAsync(id);
        if (author == null) return NotFound();

        return Ok(new ApiAuthor { Id = author.Id, Name = author.Name });
    }

    [HttpPost]
    public async Task<ActionResult<ApiAuthor>> Create([FromBody] ApiCreateAuthor model)
    {
        var entity = new DbAuthor
        {
            Name = model.Name
        };

        var created = await _authors.CreateAsync(entity);
        if (!created) return BadRequest();

      //  await _authors.SaveAsync();

        return CreatedAtAction(nameof(GetById), new { id = entity.Id },
            new ApiAuthor { Id = entity.Id, Name = entity.Name });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ApiAuthor model)
    {
        if (id != model.Id) return BadRequest();

        var existing = await _authors.ReadAsync(id);
        if (existing == null) return NotFound();

        existing.Name = model.Name;

        var updated = await _authors.UpdateAsync(existing);
        if (!updated) return BadRequest();

       // await _authors.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _authors.ReadAsync(id);
        if (existing == null) return NotFound();

        var removed = await _authors.RemoveAsync(existing);
        if (!removed) return BadRequest();

       // await _authors.SaveAsync();
        return NoContent();
    }
}
