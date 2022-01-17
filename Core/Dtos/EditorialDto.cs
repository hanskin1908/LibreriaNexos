using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
  public   class EditorialDto
    {
        [Required(ErrorMessage = "El IdEditorial es obligatorio")]
        public int IdEditorial { get; set; }
        [Required(ErrorMessage = "El Nombre de la editorial es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La direccion de la editorial es obligatoria")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El telefono de la editorial es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo de la editorial es obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El Maximo de libros registrados  es obligatorio")]
        public int? MaximoLibrosReg { get; set; }

  
    }
}
