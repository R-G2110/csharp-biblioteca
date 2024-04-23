namespace csharp_biblioteca
{
    // La classe Book si estende sulla classe Document (classe Book eredita le proprietà della classe Document)
    public class Book : Document
    {
        public int NumberOfPages { get; set; }

        public Book(string code, string title, int year, string sector, string shelf, Author author, int numberOfPages)
            : base(code, title, year, sector, shelf, author)
        {
            NumberOfPages = numberOfPages;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title} ({Year})");
            Console.WriteLine($"Code: {Code}");
            Console.WriteLine($"Sector: {Sector}, Shelf: {Shelf}");
            Console.WriteLine($"Number of Pages: {NumberOfPages}");
            Console.WriteLine($"Author: {Author.Name} {Author.LastName}");
        }
    }
}
