namespace Library.Common
{
    // Базовий клас для людей
    public class Person : Identifiable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person() { }
    }
}
