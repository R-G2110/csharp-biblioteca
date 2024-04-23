namespace csharp_biblioteca
{
    public class Document
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Sector { get; set; }
        public string Shelf { get; set; }
        public Author Author { get; set; }

        public Document(string code, string title, int year, string sector, string shelf, Author author)
        {
            Code = code;
            Title = title;
            Year = year;
            Sector = sector;
            Shelf = shelf;
            Author = author;
        }
    }
}