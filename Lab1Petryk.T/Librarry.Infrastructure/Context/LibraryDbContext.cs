using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Librarry.Infrastructure.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Library.Infrastructure.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API зв’язки тут
        }
    }
}