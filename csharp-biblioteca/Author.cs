namespace csharp_biblioteca
{
    public class Author
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Author() { } // Costruttore di default

        public Author(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
