using System;
using Library.Common;

namespace Library.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //  CRUD сервіс для книг
            var bookService = new CrudService<Book>();

            //  книги
            bookService.Create(new Book("Кобзар", 300, "Поезія"));
            bookService.Create(new Book("Мартин Боруля", 150, "Драма"));
            bookService.Create(new Book("Тіні забутих предків", 220, "Проза"));

            Console.WriteLine(" Список усіх книг:");
            foreach (var book in bookService.ReadAll())
            {
                Console.WriteLine($"ID: {book.Id}, Назва: {book.Title}, Сторінок: {book.Pages}, Жанр: {book.Genre}");
            }

            Console.WriteLine("\n Програму виконано успішно!");
            Console.ReadKey(); 
        }
    }
}
