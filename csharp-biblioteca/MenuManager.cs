using System.Xml.Linq;

namespace csharp_biblioteca
{
    public class MenuManager
    {
        public static void DisplayMainMenu(Library library)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n-- MENU PRINCIPALE --");
                Console.WriteLine("1. Registra un documento in prestito");
                Console.WriteLine("2. Visualizza lista documenti in prestito");
                Console.WriteLine("3. Ricerca documento in prestito");
                Console.WriteLine("4. Cancellazione prestito");
                Console.WriteLine("5. Esci");
                Console.Write("Scegli un'opzione: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RegisterDocumentLend(library);
                            break;
                        case 2:
                            DisplayAllLendedDocuments(library);
                            break;
                        case 3:
                            SearchLendedDocument(library);
                            break;
                        case 4:
                            CancelLend(library);
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opzione non valida. Per favore, inserisci un numero tra 1 e 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido. Per favore inserisci un numero.");
                }
            }
        }


        private static void RegisterDocumentLend(Library library)
        {
            Console.WriteLine("==================================================================================");
            Console.WriteLine("\n-- Registrazione di un nuovo prestito --");

            // Chiedi il codice del documento all'utente
            Console.Write("\nInserisci il codice del documento: ");
            string codiceDocumento = Console.ReadLine();

            // Verifica se il documento esiste
            Document documento = library.FindLendedDocumentUsingCode(codiceDocumento);
            if (documento == null)
            {
                Console.WriteLine("Il documento non esiste nella libreria.");
                return;
            }

            // Chiedi il nome e il cognome dell'utente
            Console.Write("Inserisci il nome dell'utente: ");
            string nomeUtente = Console.ReadLine();
            Console.Write("Inserisci il cognome dell'utente: ");
            string cognomeUtente = Console.ReadLine();

            // Verifica se l'utente esiste
            User utente = library.Utenti.FirstOrDefault(u => u.Name == nomeUtente && u.LastName == cognomeUtente);
            if (utente == null)
            {
                Console.WriteLine("L'utente non esiste nella lista degli utenti.");
                return;
            }

            // Chiedi la data di inizio e la data di fine del prestito
            Console.Write("Inserisci la data di inizio del prestito (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataInizio))
            {
                Console.WriteLine("Formato data non valido.");
                return;
            }
            Console.Write("Inserisci la data di fine del prestito (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataFine))
            {
                Console.WriteLine("Formato data non valido.");
                return;
            }

            // Registra il prestito
            library.RegisterLendedDocument(utente, documento, dataInizio, dataFine);
            Console.WriteLine("Prestito registrato con successo.");
        }

        private static void DisplayAllLendedDocuments(Library library)
        {
            Console.WriteLine("-- Tutti i documenti in prestito --");
            library.PrintAllLendedDocuments();
        }

        private static void SearchLendedDocument(Library library)
        {
            Console.WriteLine("\n-- Ricerca di un documento in prestito --");

            // Chiedi il nome e il cognome dell'utente
            Console.Write("Inserisci il nome dell'utente: ");
            string nomeUtente = Console.ReadLine();
            Console.Write("Inserisci il cognome dell'utente: ");
            string cognomeUtente = Console.ReadLine();

            // Verifica se l'utente esiste nella lista degli utenti
            User utente = library.Utenti.FirstOrDefault(u => u.Name == nomeUtente && u.LastName == cognomeUtente);
            if (utente == null)
            {
                Console.WriteLine("L'utente non esiste nella lista degli utenti.");
                return;
            }

            // Trova i documenti in prestito all'utente
            List<LendedDocument> documentiInPrestito = library.FindLendedDocumentUsingUser(cognomeUtente, nomeUtente);

            // Stampa i dettagli dei documenti trovati
            if (documentiInPrestito.Count > 0)
            {
                Console.WriteLine($"\n-- Documenti in prestito all'utente {nomeUtente} {cognomeUtente} --");
                foreach (var prestito in documentiInPrestito)
                {
                    Console.WriteLine($"Titolo: {prestito.Documento.Title}");
                    Console.WriteLine($"Tipo di documento: {(prestito.Documento is Book ? "libro" : "DVD")}");
                    Console.WriteLine($"Data di inizio prestito: {prestito.DataInizio}");
                    Console.WriteLine($"Data di fine prestito: {prestito.DataFine}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Nessun documento in prestito all'utente {nomeUtente} {cognomeUtente}.");
            }
        }


        public static void CancelLend(Library library)
        {
            Console.WriteLine("\n-- Cancellazione di un prestito --");

            // Ask for the name and surname of the user
            Console.Write("Inserisci il nome dell'utente: ");
            string nome = Console.ReadLine().Trim().ToLower(); // Convert to lowercase
            Console.Write("Inserisci il cognome dell'utente: ");
            string cognome = Console.ReadLine().Trim().ToLower(); // Convert to lowercase

            // Find all documents lent to the user
            List<Document> documentsLent = new List<Document>();
            foreach (LendedDocument lending in library.Prestiti)
            {
                if (lending.Utente.Name.ToLower() == nome && lending.Utente.LastName.ToLower() == cognome)
                {
                    documentsLent.Add(lending.Documento);
                }
            }

            if (documentsLent.Count == 0)
            {
                Console.WriteLine("Nessun documento trovato per questo utente.");
                return;
            }

            // Display all documents lent to the user
            Console.WriteLine("\nDocumenti prestati all'utente:");
            for (int i = 0; i < documentsLent.Count; i++)
            {
                string documentType = (documentsLent[i] is Book) ? "libro" : "DVD";
                Console.WriteLine($"{i + 1}. {documentsLent[i].Title} ({documentType})");
            }

            // Ask the user which record to cancel
            Console.Write("Inserisci il numero del documento da cancellare: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > documentsLent.Count)
            {
                Console.Write("Inserisci un numero valido: ");
            }

            // Remove the selected lending record
            // Here you need to implement the removal of the lending record from the Prestiti list
            // I'll assume you have a method like RemoveLendedDocument in the Library class
            library.RemoveLendedDocument(documentsLent[choice - 1], nome, cognome);
            Console.WriteLine("Prestito cancellato con successo.");
        }





    }
}
