using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
  public  class LibroDto
    {
        [Required(ErrorMessage = "El idISBN es obligatorio")]
        public int Idisbn { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El Año es obligatorio")]
        public int? Anio { get; set; }
        [Required(ErrorMessage = "El Genero es obligatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El Numero de paginas es obligatorio")]
        public int? NumeroPaginas { get; set; }

        [Required(ErrorMessage = "El idEditorial es obligatorio")]
        public int IdEditorial { get; set; }

        [Required(ErrorMessage = "El IdAutor es obligatorio")]
        public int IdAutor { get; set; }

 

    }
}
