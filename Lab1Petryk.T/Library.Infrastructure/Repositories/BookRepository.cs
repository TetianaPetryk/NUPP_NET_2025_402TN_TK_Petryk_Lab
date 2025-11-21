using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository
    {
        private readonly LibraryDbContext _context;

        // Конструктор приймає екземпляр DbContext
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        // Додати книгу
        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        // Отримати всі книги
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // Отримати книгу за ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        // Оновити дані книги
        public async Task UpdateBookAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Видалити книгу
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
