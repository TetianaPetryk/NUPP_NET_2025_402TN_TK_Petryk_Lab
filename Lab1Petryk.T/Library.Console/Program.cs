using Library.Infrastruct.Context;
using Library.Infrastruct.Models;
using Library.Infrastruct.Repositories;
using Library.Infrastruct.Services;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ✅ 1) Робимо options для DbContext (так само як у REST)
var options = new DbContextOptionsBuilder<LibraryDbContext>()
    .UseSqlite("Data Source=library.db")
    .Options;

// ✅ 2) Створюємо контекст з options
using var context = new LibraryDbContext(options);

// ✅ 3) Міграції
await context.Database.MigrateAsync();

// ✅ 4) Репозиторій і CRUD
var bookRepository = new Repository<BookModel>(context);
var bookService = new CrudServiceAsync<BookModel>(bookRepository);

// ✅ 5) Додаємо книги
await bookService.CreateAsync(new BookModel
{
    Title = "Кобзар",
    Pages = 300,
    Genre = "Поезія",
    Author = new AuthorModel { Name = "Тарас Шевченко" }
});

await bookService.CreateAsync(new BookModel
{
    Title = "Мартин Боруля",
    Pages = 150,
    Genre = "Драма",
    Author = new AuthorModel { Name = "Іван Карпенко-Карий" }
});

await bookService.CreateAsync(new BookModel
{
    Title = "Тіні забутих предків",
    Pages = 220,
    Genre = "Проза",
    Author = new AuthorModel { Name = "Михайло Коцюбинський" }
});

// ⚠️ Якщо у твоєму CrudServiceAsync CreateAsync НЕ робить SaveChanges автоматично,
// тоді розкоментуй (або виклич SaveChanges напряму):
// await bookService.SaveAsync();
// або:
// await context.SaveChangesAsync();

Console.WriteLine("📚 Список усіх книг:");
var books = await bookService.ReadAllAsync();

foreach (var book in books)
{
    Console.WriteLine($"ID: {book.Id}, Назва: {book.Title}, Сторінок: {book.Pages}, Жанр: {book.Genre}, Автор: {book.Author?.Name}");
}

Console.WriteLine("\n✅ Програму виконано успішно!");
Console.ReadKey();
