using System;
using System.Collections.Generic;

#nullable disable

namespace Infraestructure.Data
{
    public partial class Libro
    {
        public int Idisbn { get; set; }
        public string Titulo { get; set; }
        public int? Anio { get; set; }
        public string Genero { get; set; }
        public int? NumeroPaginas { get; set; }
        public int? IdEditorial { get; set; }
        public int? IdAutor { get; set; }


    
    }
}
