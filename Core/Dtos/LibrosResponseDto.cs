using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
 public   class LibrosResponseDto
    {

 public int Idisbn { get; set; }
        public string Titulo { get; set; }
        public string Anio { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public string Editorial { get; set; }
        public string NombreAutor { get; set; }
    }
}
