using Microsoft.AspNetCore.Mvc;
using Library.Infrastruct.Services;

// Аліаси
using DbBook = Library.Infrastruct.Models.BookModel;
using DbAuthor = Library.Infrastruct.Models.AuthorModel;

using ApiBook = Library.REST.Models.BookModel;
using ApiCreateBook = Library.REST.Models.CreateBookModel;

namespace Library.REST.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ICrudServiceAsync<DbBook> _books;
    private readonly ICrudServiceAsync<DbAuthor> _authors;

    public BooksController(ICrudServiceAsync<DbBook> books, ICrudServiceAsync<DbAuthor> authors)
    {
        _books = books;
        _authors = authors;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApiBook>>> GetAll()
    {
        var items = await _books.ReadAllAsync();
        return Ok(items.Select(b => new ApiBook
        {
            Id = b.Id,
            Title = b.Title,
            Pages = b.Pages,
            Genre = b.Genre,
            AuthorId = b.AuthorId
        }));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiBook>> GetById(int id)
    {
        var book = await _books.ReadAsync(id);
        if (book == null) return NotFound();

        return Ok(new ApiBook
        {
            Id = book.Id,
            Title = book.Title,
            Pages = book.Pages,
            Genre = book.Genre,
            AuthorId = book.AuthorId
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiBook>> Create([FromBody] ApiCreateBook model)
    {
        // Перевіримо що автор існує
        var author = await _authors.ReadAsync(model.AuthorId);
        if (author == null) return NotFound($"Author {model.AuthorId} not found");

        var entity = new DbBook
        {
           
            Title = model.Title,
            Pages = model.Pages,
            Genre = model.Genre,
            AuthorId = model.AuthorId
        };

        var created = await _books.CreateAsync(entity);
        if (!created) return BadRequest();

     //   await _books.SaveAsync();

        return CreatedAtAction(nameof(GetById), new { id = entity.Id },
            new ApiBook
            {
                Id = entity.Id,
                Title = entity.Title,
                Pages = entity.Pages,
                Genre = entity.Genre,
                AuthorId = entity.AuthorId
            });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ApiBook model)
    {
        if (id != model.Id) return BadRequest();

        var existing = await _books.ReadAsync(id);
        if (existing == null) return NotFound();

        var author = await _authors.ReadAsync(model.AuthorId);
        if (author == null) return NotFound($"Author {model.AuthorId} not found");

        existing.Title = model.Title;
        existing.Pages = model.Pages;
        existing.Genre = model.Genre;
        existing.AuthorId = model.AuthorId;

        var updated = await _books.UpdateAsync(existing);
        if (!updated) return BadRequest();

       // await _books.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _books.ReadAsync(id);
        if (existing == null) return NotFound();

        var removed = await _books.RemoveAsync(existing);
        if (!removed) return BadRequest();

      //  await _books.SaveAsync();
        return NoContent();
    }
}
