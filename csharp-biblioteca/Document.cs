using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Document
    {
        // Proprietà classe Document
        public string Code { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Sector { get; set; }
        public string Shelf { get; set; }
        public Author Author { get; set; }
    }

}
