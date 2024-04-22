namespace csharp_biblioteca
{
    public class Library
    {
        public List<Document> Documenti { get; set; }
        public List<User> Utenti { get; set; }
        public List<LendedDocument> Prestiti { get; set; }

        public Library()
        {
            Documenti = new List<Document>();
            Utenti = new List<User>();
            Prestiti = new List<LendedDocument>();
        }

        public void AddDocument(Document documento)
        {
            Documenti.Add(documento);
        }

        public void AddUser(User utente)
        {
            Utenti.Add(utente);
        }

        public void RegisterLendedDocument(User utente, Document documento, DateTime dataInizio, DateTime dataFine)
        {
            LendedDocument prestito = new LendedDocument
            {
                Utente = utente,
                Documento = documento,
                DataInizio = dataInizio,
                DataFine = dataFine
            };
            Prestiti.Add(prestito);
        }

        public List<LendedDocument> FindLendedDocumentUsingUser(string cognome, string nome)
        {
            return Prestiti.FindAll(p => p.Utente.LastName == cognome && p.Utente.Name == nome);
        }

        public Document FindLendedDocumentUsingCode(string codice)
        {
            return Documenti.Find(d => d.Code == codice);
        }

        public List<Document> FindLendedDocumentUsingTitle(string titolo)
        {
            return Documenti.FindAll(d => d.Title.Contains(titolo));
        }
        public void PrintAllLendedDocuments()
        {
            Console.WriteLine($"================================================================================");
            Console.WriteLine($"\n-- Lista documenti prestati --");
            Console.WriteLine();
            foreach (LendedDocument prestito in Prestiti)
            {
                if (prestito.Documento is Book)
                {
                    Book libro = prestito.Documento as Book;
                    Console.WriteLine($"Tipo documento: Libro");
                    Console.WriteLine($"Titolo: {libro.Title}");
                    Console.WriteLine($"Numero di pagine: {libro.NumberOfPages}");
                }
                else if (prestito.Documento is DVD)
                {
                    DVD dvd = prestito.Documento as DVD;
                    Console.WriteLine($"Tipo documento: DVD");
                    Console.WriteLine($"Titolo: {dvd.Title}");
                    Console.WriteLine($"Durata: {dvd.Duration} minuti");
                }
                else
                {
                    Console.WriteLine($"Tipo documento sconosciuto");
                }
                Console.WriteLine($"Prestato a: {prestito.Utente.Name} {prestito.Utente.LastName}");
                Console.WriteLine($"Data inizio: {prestito.DataInizio.ToShortDateString()}  \nData fine: {prestito.DataFine.ToShortDateString()}");
                Console.WriteLine();
            }
        }
        public void RemoveLendedDocument(Document document, string nome, string cognome)
        {
            // Find the lending record to remove
            LendedDocument lendingToRemove = Prestiti.FirstOrDefault(p => p.Documento == document && p.Utente.Name == nome && p.Utente.LastName == cognome);

            if (lendingToRemove != null)
            {
                // Remove the lending record
                Prestiti.Remove(lendingToRemove);
            }
        }

    }
}
