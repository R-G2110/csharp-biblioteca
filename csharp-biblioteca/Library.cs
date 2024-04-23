namespace csharp_biblioteca
{
    public class Library
    {
        public List<Document> Documents { get; private set; }
        public List<User> Users { get; private set; }
        public List<LendedDocument> Lendings { get; private set; }

        public Library()
        {
            Documents = new List<Document>();
            Users = new List<User>();
            Lendings = new List<LendedDocument>();
        }

        public void AddDocument(Document document)
        {
            Documents.Add(document);
        }
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public void RegisterLending(User user, Document document, DateTime startDate, DateTime endDate)
        {
            LendedDocument lending = new LendedDocument
            {
                User = user,
                Document = document,
                StartDate = startDate,
                EndDate = endDate
            };
            Lendings.Add(lending);
        }
        public List<LendedDocument> FindLendingsByUser(string lastName, string firstName)
        {
            return Lendings.FindAll(l => l.User.LastName == lastName && l.User.Name == firstName);
        }
        public Document FindDocumentByCode(string code)
        {
            return Documents.Find(d => d.Code.ToLower() == code.ToLower());
        }
        public List<Document> FindDocumentsByTitle(string title)
        {
            return Documents.FindAll(d => d.Title.ToLower().Contains(title));
        }
        public void PrintAllLendings()
        {
            Utility.Divider();
            Console.WriteLine($"\n-- Lista documenti prestati --");
            Console.WriteLine();

            if (Lendings.Count == 0)
            {
                Console.WriteLine("No lendings found.");
                return;
            }

            foreach (LendedDocument lending in Lendings)
            {
                if (lending.Document is Book book)
                {
                    Console.WriteLine($"* Book:        {book.Title} ({book.Year})");
                    Console.WriteLine($"  Code:        {book.Code}");
                    Console.WriteLine($"  Sector:      {book.Sector}, Shelf: {book.Shelf}");
                    Console.WriteLine($"  N° of Pages: {book.NumberOfPages}");
                    Console.WriteLine($"  Author:      {book.Author.Name.ToUpper()} {book.Author.LastName.ToUpper()}");
                }
                else if (lending.Document is DVD dvd)
                {
                    Console.WriteLine($"* DVD:         {dvd.Title} ({dvd.Year})");
                    Console.WriteLine($"  Code:        {dvd.Code}");
                    Console.WriteLine($"  Sector:      {dvd.Sector}, Shelf: {dvd.Shelf}");
                    Console.WriteLine($"  Duration:    {dvd.Duration} minutes");
                    Console.WriteLine($"  Author:      {dvd.Author.Name.ToUpper()} {dvd.Author.LastName.ToUpper()}");
                }
                else
                {
                    Console.WriteLine($"Unknown document type");
                }
                Console.WriteLine($"  Lent to:     {lending.User.Name.ToUpper()} {lending.User.LastName.ToUpper()}");
                Console.WriteLine($"  Start Date:  {lending.StartDate.ToShortDateString()}");
                Console.WriteLine($"  End Date:    {lending.EndDate.ToShortDateString()}");
                Console.WriteLine();
            }
        }
        public void RemoveLending(Document document, string firstName, string lastName)
        {
            LendedDocument lendingToRemove = Lendings.Find(l => l.Document == document && l.User.Name == firstName && l.User.LastName == lastName);

            if (lendingToRemove != null)
            {
                Lendings.Remove(lendingToRemove);
            }
        }
        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }
        public void RemoveDocument(Document document)
        {
            Documents.Remove(document);
        }

    }
}
