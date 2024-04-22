using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    // La classe Book si estende sulla classe Document (classe Book eredita le proprietà della classe Document)
    internal class Book : Document
    {
        // Proprietà classe Book
        public int NumberOfPages { get; set; }
    }

}
