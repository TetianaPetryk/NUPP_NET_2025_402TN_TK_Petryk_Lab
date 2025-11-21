using Library.Common;

namespace Library.Common
{
    public class Book : Identifiable
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }

       public Reader Reader { get; set; }

        public Book(string title, int pages, string genre, Reader reader)
        {
            Title = title;
            Pages = pages;
            Genre = genre;
            Reader = reader;
        }
    }
}
