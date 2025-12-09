using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastruct.Models
{
        public class AuthorModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;

            public ICollection<BookModel> Books { get; set; } = new List<BookModel>();
        }
    }

