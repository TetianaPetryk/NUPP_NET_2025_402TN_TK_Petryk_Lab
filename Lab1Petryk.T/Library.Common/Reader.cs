using System.Text.Json.Serialization;
using Library.Common;

namespace Library.Common
{
    // Читач наслідує Person
    public class Reader : Person
    {
        public string FavoriteGenre { get; set; }

        public Reader() { }

        public Reader(string name, int age, string favoriteGenre)
            : base(name, age)
        {
            FavoriteGenre = favoriteGenre;
        }
    }
}
