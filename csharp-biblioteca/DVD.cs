using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    // La classe DVD si estende sulla classe Document (classe DVD eredita le proprietà della classe Document)
    internal class DVD : Document
    {
        // Proprietà classe DVD
        public int Duration { get; set; }
    }

}
