namespace Library.REST.Models;

public class CreateBookModel
{
    public string Title { get; set; } = "";
    public int Pages { get; set; }
    public string Genre { get; set; } = "";
    public int AuthorId { get; set; }
}
