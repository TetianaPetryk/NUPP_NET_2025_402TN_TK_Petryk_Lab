using Library.Common;
using System.Collections.Generic;

namespace Library.Infrastruct.Models
{
    public class BookModel : Identifiable
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Pages { get; set; }

        public string Genre { get; set; } = string.Empty;

        // Зв'язок з автором (1 автор → багато книг)
        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; } = null!;

        // Зв'язок з рецензіями (1 книга → багато рецензій)
        public ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
    }
}