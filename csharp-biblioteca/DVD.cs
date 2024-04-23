using System;

namespace csharp_biblioteca
{
    public class DVD : Document
    {
        public int Duration { get; set; }

        public DVD(string code, string title, int year, string sector, string shelf, Author author, int duration)
            : base(code, title, year, sector, shelf, author)
        {
            Duration = duration;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"DVD: {Title} ({Year})");
            Console.WriteLine($"Code: {Code}");
            Console.WriteLine($"Sector: {Sector}, Shelf: {Shelf}");
            Console.WriteLine($"Duration: {Duration} minutes");
            Console.WriteLine($"Author: {Author.Name} {Author.LastName}");
        }
    }
}
