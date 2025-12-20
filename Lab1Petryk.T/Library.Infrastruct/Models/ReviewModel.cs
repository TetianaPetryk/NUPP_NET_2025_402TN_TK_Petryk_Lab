using Library.Common;

namespace Library.Infrastruct.Models
{
    public class ReviewModel : Identifiable
    {
        public int Id { get; set; }

        // Текст відгуку
        public string Text { get; set; } = string.Empty;

        // Оцінка від 1 до 5 (наприклад)
        public int Rating { get; set; }

        // Зовнішній ключ на Book
        public int BookId { get; set; }

        // Навігаційна властивість
        public BookModel Book { get; set; } = null!;
    }
}
