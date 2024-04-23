namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = SetupLibrary();
            MenuManager.DisplayMainMenu(library);
        }

        private static Library SetupLibrary()
        {
            Library library = new Library();

            List<User> users = new List<User>
            {
                new User("rossi", "mario", "mario.rossi@example.com", "password123", "123456789"),
                new User("bianchi", "laura", "laura.bianchi@example.com", "qwerty456", "987654321"),
                new User("verdi", "giovanni", "giovanni.verdi@example.com", "pass1234", "567891234"),
                new User("ferrari", "anna", "anna.ferrari@example.com", "ferrari789", "321654987"),
                new User("russo", "giuseppe", "giuseppe.russo@example.com", "russo246", "654987321")
            };
            users.ForEach(u => library.AddUser(u));

            List<Document> documents = new List<Document>
            {
                new Book("L001", "Il Signore degli Anelli", 1954, "Fantasy", "A1", new Author("J.R.R.", "Tolkien"), 1178),
                new DVD("D002", "1984", 1949, "Dystopian Fiction", "B2", new Author("George", "Orwell"), 180),
                new Book("L003", "Cronache del ghiaccio e del fuoco: Il trono di spade", 1996, "Fantasy", "C3", new Author("George R.R.", "Martin"), 694),
                new DVD("D004", "Harry Potter e la pietra filosofale", 1997, "Fantasy", "D4", new Author("J.K.", "Rowling"), 180),
                new Book("L005", "Il vecchio e il mare", 1952, "Fiction", "E5", new Author("Ernest", "Hemingway"), 127),
                new DVD("D006", "Guerra e pace", 1869, "Historical Fiction", "F6", new Author("Lev", "Tolstoj"), 125),
                new Book("L007", "Il giovane Holden", 1951, "Fiction", "G7", new Author("J.D.", "Salinger"), 277),
                new DVD("D008", "Il nome della rosa", 1980, "Historical Fiction", "H8", new Author("Umberto", "Eco"), 136),
                new Book("L009", "Orgoglio e pregiudizio", 1813, "Romance", "I9", new Author("Jane", "Austen"), 279),
                new DVD("D010", "Il conte di Montecristo", 1844, "Adventure", "J10", new Author("Alexandre", "Dumas"), 126)
            };
            documents.ForEach(d => library.AddDocument(d));

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(14);
            library.RegisterLending(users[0], documents[0], startDate, endDate);
            library.RegisterLending(users[0], documents[1], startDate, endDate);
            library.RegisterLending(users[1], documents[2], startDate, endDate);
            library.RegisterLending(users[1], documents[3], startDate, endDate);

            return library;
        }
    }
}
