using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
  public   class AutorDto
    {
        [Required(ErrorMessage = "El IdAutor es obligatorio")]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El Nombre del autor es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Fecha de Nacimiento es obligatorio")]
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = "La ciudad de procedencia es obligatorio")]
        public string CiudadProced { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Correo { get; set; }


    }
}
