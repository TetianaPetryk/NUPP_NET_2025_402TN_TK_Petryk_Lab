namespace Library.Common
{
    public class Book : Identifiable
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }

        public Book(string title, int pages, string genre)
        {
            Title = title;
            Pages = pages;
            Genre = genre;
        }
    }
}
