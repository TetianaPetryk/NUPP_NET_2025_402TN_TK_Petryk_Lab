using Librarry.Infrastructure.Models;
using Library.Common;

namespace Library.Infrastructure.Models
{
    public class BookModel : IIdentifiable
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Genre { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; } = null!;
        public ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
    }
}