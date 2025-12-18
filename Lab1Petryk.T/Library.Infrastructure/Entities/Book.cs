using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Infrastructure.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Genre { get; set; }

        [Range(0, 9999)]
        public int Year { get; set; }

        public double Price { get; set; }
    }
}