using System;
using System.IO;
using Library.Infrastruct.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastruct.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; } = null!;
        public DbSet<AuthorModel> Authors { get; set; } = null!;
        public DbSet<ReviewModel> Reviews { get; set; } = null!;

        // OnModelCreating лишаємо як є, його не чіпаємо

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // База завжди лежить поруч із .exe файлом (bin\Debug\net8.0)
                var dbPath = Path.Combine(AppContext.BaseDirectory, "Library.db");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
    }
}
