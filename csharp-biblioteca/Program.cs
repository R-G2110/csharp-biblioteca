namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library biblioteca = SetupLibrary();
            MenuManager.DisplayMainMenu(biblioteca);
        }

        private static void DisplayMainMenu()
        {
            string[] menu = { "Registrazione documento in prestito", "Visualizza lista documenti in prestito", "Ricerca documento in prestito", "Cancellazione prestito" };
            Console.WriteLine("-- MENU --\n");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }
        }

        private static void DisplayUserLendedDocuments(Library library, string lastName, string firstName)
        {
            var lendedDocuments = library.FindLendedDocumentUsingUser(lastName, firstName);
            Console.WriteLine($"-- Lista documenti prestati a: {firstName} {lastName} --\n");
            foreach (var lended in lendedDocuments)
            {
                Console.WriteLine($"{lended}");
            }
        }

        private static void DisplayAllLendedDocuments(Library library)
        {
            Console.WriteLine("-- Tutti i documenti in prestito --");
            library.PrintAllLendedDocuments();
        }

        private static Library SetupLibrary()
        {
            Library biblioteca = new Library();
            // Aggiunta utenti
            List<User> users = new List<User>
            {
                new User { LastName = "Rossi", Name = "Mario", Email = "mario.rossi@example.com", Password = "password123", TelNumber = "123456789" },
                new User { LastName = "Bianchi", Name = "Laura", Email = "laura.bianchi@example.com", Password = "qwerty456", TelNumber = "987654321" },
                new User { LastName = "Verdi", Name = "Giovanni", Email = "giovanni.verdi@example.com", Password = "pass1234", TelNumber = "567891234" },
                new User { LastName = "Ferrari", Name = "Anna", Email = "anna.ferrari@example.com", Password = "ferrari789", TelNumber = "321654987" },
                new User { LastName = "Russo", Name = "Giuseppe", Email = "giuseppe.russo@example.com", Password = "russo246", TelNumber = "654987321" }
            };
            users.ForEach(u => biblioteca.AddUser(u));

            // Aggiunta documenti
            List<Document> documents = new List<Document>
            {
                new Book { Code = "L001", Title = "Il Signore degli Anelli", Year = 1954, Sector = "Fantasy", Shelf = "A1", Author = new Author { Name = "J.R.R.", LastName = "Tolkien" }, NumberOfPages = 1178 },
                new DVD { Code = "D002", Title = "1984", Year = 1949, Sector = "Dystopian Fiction", Shelf = "B2", Author = new Author { Name = "George", LastName = "Orwell" }, Duration = 180 },
                new Book { Code = "L003", Title = "Cronache del ghiaccio e del fuoco: Il trono di spade", Year = 1996, Sector = "Fantasy", Shelf = "C3", Author = new Author { Name = "George R.R.", LastName = "Martin" }, NumberOfPages = 694 },
                new DVD  { Code = "D004", Title = "Harry Potter e la pietra filosofale", Year = 1997, Sector = "Fantasy", Shelf = "D4", Author = new Author { Name = "J.K.", LastName = "Rowling" }, Duration = 180 },
                new Book  { Code = "L005", Title = "Il vecchio e il mare", Year = 1952, Sector = "Fiction", Shelf = "E5", Author = new Author { Name = "Ernest", LastName = "Hemingway" }, NumberOfPages = 127 },
                new DVD { Code = "D006", Title = "Guerra e pace", Year = 1869, Sector = "Historical Fiction", Shelf = "F6", Author = new Author { Name = "Lev", LastName = "Tolstoj" }, Duration = 125 },
                new Book { Code = "L007", Title = "Il giovane Holden", Year = 1951, Sector = "Fiction", Shelf = "G7", Author = new Author { Name = "J.D.", LastName = "Salinger" }, NumberOfPages = 277 },
                new DVD { Code = "D008", Title = "Il nome della rosa", Year = 1980, Sector = "Historical Fiction", Shelf = "H8", Author = new Author { Name = "Umberto", LastName = "Eco" }, Duration = 136 },
                new Book { Code = "L009", Title = "Orgoglio e pregiudizio", Year = 1813, Sector = "Romance", Shelf = "I9", Author = new Author { Name = "Jane", LastName = "Austen" }, NumberOfPages = 279 },
                new DVD { Code = "D010", Title = "Il conte di Montecristo", Year = 1844, Sector = "Adventure", Shelf = "J10", Author = new Author { Name = "Alexandre", LastName = "Dumas" }, Duration = 126 }
                // Aggiungere altri documenti qui sotto
            };
            documents.ForEach(d => biblioteca.AddDocument(d));

            // Registrazione prestiti
            DateTime dataInizio = DateTime.Today;
            DateTime dataFine = dataInizio.AddDays(14);
            biblioteca.RegisterLendedDocument(users[0], documents[0], dataInizio, dataFine);
            biblioteca.RegisterLendedDocument(users[0], documents[1], dataInizio, dataFine);

            return biblioteca;
        }
    }
}
