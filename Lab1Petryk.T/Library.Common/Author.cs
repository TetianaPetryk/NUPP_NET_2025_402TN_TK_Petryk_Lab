namespace Library.Common
{
    // Автор наслідує Person
    public class Author : Person
    {
        public int BirthYear { get; set; }
        public string Nationality { get; set; }

        public Author() { }

        public Author(string name, int age, int birthYear, string nationality)
            : base(name, age)
        {
            BirthYear = birthYear;
            Nationality = nationality;
        }
    }
}

