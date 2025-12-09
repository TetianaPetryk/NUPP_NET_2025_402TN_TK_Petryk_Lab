using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;



namespace Library.Infrastruct.Context
{

        public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
        {
            public LibraryDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
                optionsBuilder.UseSqlite("Data Source=Library.db");
                return new LibraryDbContext(optionsBuilder.Options);
            }
        }
}
