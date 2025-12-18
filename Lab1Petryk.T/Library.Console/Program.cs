using Library.Infrastruct.Context;
using Library.Infrastruct.Models;
using Library.Infrastruct.Repositories;
using Library.Infrastruct.Services;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// 1. Створюємо контекст – він сам налаштується в OnConfiguring
using var context = new LibraryDbContext();

// 2. Гарантуємо, що всі міграції застосовані до ЦІЄЇ бази
await context.Database.MigrateAsync();

// 3. Репозиторій і CRUD-сервіс
var bookRepository = new Repository<BookModel>(context);
var bookService = new CrudServiceAsync<BookModel>(bookRepository);

// 4. Створюємо книги
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

// 5. Зберігаємо через сервіс
//await bookService.SaveAsync();

// 6. Виводимо результат
Console.WriteLine("📚 Список усіх книг:");
var books = await bookService.ReadAllAsync();

foreach (var book in books)
{
    Console.WriteLine(
        $"ID: {book.Id}, Назва: {book.Title}, Сторінок: {book.Pages}, Жанр: {book.Genre}, Автор: {book.Author?.Name}"
    );
}

Console.WriteLine("\n✅ Програму виконано успішно!");
Console.ReadKey();
