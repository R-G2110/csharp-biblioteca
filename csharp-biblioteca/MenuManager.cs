//using System.Globalization;
//using System.Xml.Linq;

//namespace csharp_biblioteca
//{
//    public class MenuManager
//    {
//        public static void DisplayMainMenu(Library library)
//        {
//            bool exit = false;
//            while (!exit)
//            {
//                Utility.Divider();
//                Console.WriteLine("-- MAIN MENU --");
//                Console.WriteLine("1. Register user");
//                Console.WriteLine("2. Register a document lending");
//                Console.WriteLine("3. Display all lended documents");
//                Console.WriteLine("4. Search for a document by code / title");
//                Console.WriteLine("5. Search document using username");
//                Console.WriteLine("6. Cancel a lending");
//                Console.WriteLine("7. Exit");
//                Console.Write("Choose an option: ");

//                string input = Console.ReadLine();
//                int choice;
//                if (int.TryParse(input, out choice))
//                {
//                    switch (choice)
//                    {
//                        case 1:
//                            RegisterUser(library);
//                            break;
//                        case 2:
//                            RegisterDocumentLending(library);
//                            break;
//                        case 3:
//                            DisplayAllLendings(library);
//                            break;
//                        case 4:
//                            // to implement
//                            break;
//                        case 5:
//                            SearchLendedDocument(library);
//                            break;
//                        case 6:
//                            CancelLending(library);
//                            break;
//                        case 7:
//                            exit = true;
//                            break;
//                        default:
//                            Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
//                            break;
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Invalid input. Please enter a number.");
//                }
//            }
//        }
//        private static void RegisterUser(Library library)
//        {
//            Utility.Divider();
//            Console.WriteLine("-- Registering a new user --");

//            Console.Write("Enter the user's first name: ");
//            string firstName = Console.ReadLine().Trim();
//            Console.Write("Enter the user's last name: ");
//            string lastName = Console.ReadLine().Trim();
//            // Verifica se l'utente esiste già nella libreria
//            if (library.Users.Any(u => u.Name.Equals(firstName, StringComparison.OrdinalIgnoreCase) && u.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)))
//            {
//                Console.WriteLine("\nAttention!!! \nThe user is already registered.");
//                return;
//            }
//            Console.Write("Enter the user's email: ");
//            string email = Console.ReadLine().Trim();
//            Console.Write("Enter the user's password: ");
//            string password = Console.ReadLine().Trim();
//            Console.Write("Enter the user's phone number: ");
//            string phoneNumber = Console.ReadLine().Trim();

//            // Crea un nuovo utente e aggiungilo alla lista degli utenti della libreria
//            User newUser = new User(firstName, lastName, email, password, phoneNumber);
//            library.AddUser(newUser);

//            Console.WriteLine("User registered successfully.");
//        }


//        private static void RegisterDocumentLending(Library library)
//        {
//            Utility.Divider();
//            Console.WriteLine("-- Registering a new lending --");

//            Console.Write("\nEnter the document code: ");
//            string documentCode = Console.ReadLine().ToLower(); // Converti il codice in minuscolo

//            Document document = library.FindDocumentByCode(documentCode);
//            if (document == null)
//            {
//                Console.WriteLine("\nAttention!!! \nThe document does not exist in the library.");
//                Console.WriteLine("Please register the document first.");
//                return;
//            }

//            Console.Write("Enter the user's first name: ");
//            string userFirstName = Console.ReadLine().ToLower(); // Converti il nome in minuscolo
//            Console.Write("Enter the user's last name: ");
//            string userLastName = Console.ReadLine().ToLower(); // Converti il cognome in minuscolo

//            // Confronto case-insensitive dei nomi degli utenti
//            User user = library.Users.Find(u => u.Name.ToLower() == userFirstName && u.LastName.ToLower() == userLastName);
//            if (user == null)
//            {
//                Console.WriteLine("\nAttention!!! \nThe user not yet registered.");
//                Console.WriteLine("Please register the user first.");
//                return;
//            }

//            // Imposta la data di oggi come data di inizio predefinita
//            DateTime startDate = DateTime.Today;

//            // Imposta l'endDate a un mese di distanza dalla startDate
//            DateTime endDate = startDate.AddMonths(1);

//            Console.WriteLine($"Default start date set to: {startDate.ToShortDateString()}");
//            Console.WriteLine($"Default end date set to: {endDate.ToShortDateString()}");

//            library.RegisterLending(user, document, startDate, endDate);
//            Console.WriteLine("Lending registered successfully.");
//        }

//        private static void DisplayAllLendings(Library library)
//        {
//            Console.WriteLine("-- All lended documents --");
//            library.PrintAllLendings();
//        }

//        private static void SearchLendedDocument(Library library)
//        {
//            Console.WriteLine("\n-- Search for a lended document --");

//            Console.Write("Enter the user's first name: ");
//            string userFirstName = Console.ReadLine();
//            Console.Write("Enter the user's last name: ");
//            string userLastName = Console.ReadLine();

//            User user = library.Users.Find(u => u.Name == userFirstName && u.LastName == userLastName);
//            if (user == null)
//            {
//                Console.WriteLine("The user does not exist in the user list.");
//                return;
//            }

//            List<LendedDocument> lendedDocuments = library.FindLendingsByUser(userLastName, userFirstName);

//            if (lendedDocuments.Count > 0)
//            {
//                Console.WriteLine($"\n-- Lended documents for user {userFirstName} {userLastName} --");
//                foreach (var lending in lendedDocuments)
//                {
//                    Console.WriteLine($"Title: {lending.Document.Title}");
//                    Console.WriteLine($"Document type: {(lending.Document is Book ? "book" : "DVD")}");
//                    Console.WriteLine($"Start date of lending: {lending.StartDate}");
//                    Console.WriteLine($"End date of lending: {lending.EndDate}");
//                    Console.WriteLine();
//                }
//            }
//            else
//            {
//                Console.WriteLine($"No documents lended to user {userFirstName} {userLastName}.");
//            }
//        }

//        public static void CancelLending(Library library)
//        {
//            Console.WriteLine("\n-- Cancel a lending --");

//            Console.Write("Enter the user's first name: ");
//            string firstName = Console.ReadLine().Trim().ToLower();
//            Console.Write("Enter the user's last name: ");
//            string lastName = Console.ReadLine().Trim().ToLower();

//            List<Document> documentsLent = new List<Document>();
//            foreach (LendedDocument lending in library.Lendings)
//            {
//                if (lending.User.Name.ToLower() == firstName && lending.User.LastName.ToLower() == lastName)
//                {
//                    documentsLent.Add(lending.Document);
//                }
//            }

//            if (documentsLent.Count == 0)
//            {
//                Console.WriteLine("No documents found for this user.");
//                return;
//            }

//            Console.WriteLine("\nDocuments lent to the user:");
//            for (int i = 0; i < documentsLent.Count; i++)
//            {
//                string documentType = (documentsLent[i] is Book) ? "book" : "DVD";
//                Console.WriteLine($"{i + 1}. {documentsLent[i].Title} ({documentType})");
//            }

//            Console.Write("Enter the number of the document to cancel: ");
//            int choice;
//            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > documentsLent.Count)
//            {
//                Console.Write("Enter a valid number: ");
//            }

//            library.RemoveLending(documentsLent[choice - 1], firstName, lastName);
//            Console.WriteLine("Lending cancelled successfully.");
//        }
//    }
//}
namespace csharp_biblioteca
{
    public class MenuManager
    {
        public static void DisplayMainMenu(Library library)
        {
            bool exit = false;
            while (!exit)
            {
                Utility.Divider();
                Console.WriteLine("--  Library Main Menu  --");
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RegistrationSubMenu(library);
                            break;
                        case 2:
                            DisplaySubMenu(library);
                            break;
                        case 3:
                            // SearchSubMenu(library);
                            Console.WriteLine("Search submenu is not implemented yet.");
                            break;
                        case 4:
                            // DeleteSubMenu(library);
                            Console.WriteLine("Delete submenu is not implemented yet.");
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void RegistrationSubMenu(Library library)
        {
            bool exit = false;
            while (!exit)
            {
                Utility.Divider();
                Console.WriteLine("-- REGISTRATION MENU --");
                Console.WriteLine("1. Register user");
                Console.WriteLine("2. Register document");
                Console.WriteLine("3. Register a document lending");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RegisterUser(library);
                            break;
                        case 2:
                            RegisterDocument(library);
                            break;
                        case 3:
                            RegisterDocumentLending(library);
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void DisplaySubMenu(Library library)
        {
            bool exit = false;
            while (!exit)
            {
                Utility.Divider();
                Console.WriteLine("-- DISPLAY MENU --");
                Console.WriteLine("1. Display all users info");
                Console.WriteLine("2. Display all documents info");
                Console.WriteLine("3. Display all lended documents");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllUserInfo(library);
                            break;
                        case 2:
                            DisplayAllDocuments(library);
                            break;
                        case 3:
                            DisplayAllLendings(library);
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        private static void RegisterUser(Library library)
        {
            Utility.Divider();
            Console.WriteLine("-- Registering a new user --");

            Console.Write("Enter the user's first name: ");
            string firstName = Console.ReadLine().Trim();
            Console.Write("Enter the user's last name: ");
            string lastName = Console.ReadLine().Trim();
            Console.Write("Enter the user's email: ");
            string email = Console.ReadLine().Trim();
            Console.Write("Enter the user's password: ");
            string password = Console.ReadLine().Trim();
            Console.Write("Enter the user's phone number: ");
            string phoneNumber = Console.ReadLine().Trim();

            // Verifica se l'utente esiste già nella libreria
            if (library.Users.Any(u => u.Name.Equals(firstName, StringComparison.OrdinalIgnoreCase) && u.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nAttention!!! \nThe user is already registered.");
                return;
            }

            // Crea un nuovo utente e aggiungilo alla lista degli utenti della libreria
            User newUser = new User(firstName, lastName, email, password, phoneNumber);
            library.AddUser(newUser);

            Console.WriteLine("\nUser registered successfully.");
        }
        private static void RegisterDocument(Library library)
        {
            Utility.Divider();
            Console.WriteLine("-- Registering a new document --");

            Console.Write("Enter the document code: ");
            string code = Console.ReadLine();
            Console.Write("Enter the document title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the year of publication: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Invalid input. Please enter a valid year: ");
            }
            Console.Write("Enter the sector: ");
            string sector = Console.ReadLine();
            Console.Write("Enter the shelf: ");
            string shelf = Console.ReadLine();

            Console.WriteLine("\nNow, let's enter the author's information:");
            Console.Write("Enter the author's first name: ");
            string authorFirstName = Console.ReadLine();
            Console.Write("Enter the author's last name: ");
            string authorLastName = Console.ReadLine();

            Author author = new Author(authorFirstName, authorLastName);

            Console.WriteLine("\nSelect the type of document:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. DVD");
            Console.Write("Enter your choice (1 or 2): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Invalid input. Please enter 1 for Book or 2 for DVD: ");
            }

            Document document = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the number of pages: ");
                    int numberOfPages;
                    while (!int.TryParse(Console.ReadLine(), out numberOfPages))
                    {
                        Console.Write("Invalid input. Please enter a valid number of pages: ");
                    }
                    document = new Book(code, title, year, sector, shelf, author, numberOfPages);
                    break;
                case 2:
                    Console.Write("Enter the duration in minutes: ");
                    int duration;
                    while (!int.TryParse(Console.ReadLine(), out duration))
                    {
                        Console.Write("Invalid input. Please enter a valid duration in minutes: ");
                    }
                    document = new DVD(code, title, year, sector, shelf, author, duration);
                    break;
            }

            if (document != null)
            {
                library.AddDocument(document);
                Console.WriteLine("\nDocument registered successfully.");
            }
        }
        private static void RegisterDocumentLending(Library library)
        {
            Utility.Divider();
            Console.WriteLine("-- Registering a new lending --");

            Console.Write("\nEnter the document code: ");
            string documentCode = Console.ReadLine().ToLower(); // Converti il codice in minuscolo

            Document document = library.FindDocumentByCode(documentCode);
            if (document == null)
            {
                Console.WriteLine("\nAttention!!! \nThe document does not exist in the library.");
                Console.WriteLine("Please register the document first.");
                return;
            }

            Console.Write("Enter the user's first name: ");
            string userFirstName = Console.ReadLine().ToLower(); // Converti il nome in minuscolo
            Console.Write("Enter the user's last name: ");
            string userLastName = Console.ReadLine().ToLower(); // Converti il cognome in minuscolo

            // Confronto case-insensitive dei nomi degli utenti
            User user = library.Users.Find(u => u.Name.ToLower() == userFirstName && u.LastName.ToLower() == userLastName);
            if (user == null)
            {
                Console.WriteLine("\nAttention!!! \nUser not yet registered.");
                Console.WriteLine("Please register the user first.");
                return;
            }

            // Imposta la data di oggi come data di inizio predefinita
            DateTime startDate = DateTime.Today;

            // Imposta l'endDate a un mese di distanza dalla startDate
            DateTime endDate = startDate.AddMonths(1);

            Console.WriteLine($"Default start date set to: {startDate.ToShortDateString()}");
            Console.WriteLine($"Default end date set to: {endDate.ToShortDateString()}");

            library.RegisterLending(user, document, startDate, endDate);
            Console.WriteLine("Lending registered successfully.");
        }
        private static void DisplayAllUserInfo(Library library)
        {
            Utility.Divider();
            Console.WriteLine("-- All User Information --");
            foreach (var user in library.Users)
            {
                Console.WriteLine($"\n* Name:         {user.Name.ToUpper()} {user.LastName.ToUpper()}");
                Console.WriteLine($"  Email:        {user.Email}");
                Console.WriteLine($"  Phone Number: {user.TelNumber}");
            }
        }
        private static void DisplayAllDocuments(Library library)
        {
            Utility.Divider();
            Console.WriteLine("-- All Documents Information --");

            foreach (var document in library.Documents)
            {
                Console.WriteLine($"\n* Title: {document.Title}");
                Console.WriteLine($"  Code: {document.Code}");
                Console.WriteLine($"  Year: {document.Year}");
                Console.WriteLine($"  Sector: {document.Sector}");
                Console.WriteLine($"  Shelf: {document.Shelf}");
                Console.WriteLine($"  Author: {document.Author.Name} {document.Author.LastName}");

                if (document is Book book)
                {
                    Console.WriteLine($"  Type: Book");
                    Console.WriteLine($"  Number of Pages: {book.NumberOfPages}");
                }
                else if (document is DVD dvd)
                {
                    Console.WriteLine($"  Type: DVD");
                    Console.WriteLine($"  Duration: {dvd.Duration} minutes");
                }
            }
        }

        private static void DisplayAllLendings(Library library)
        {
            Utility.Divider();
            Console.WriteLine("-- All lended documents --");
            library.PrintAllLendings();
        }

    }
}
