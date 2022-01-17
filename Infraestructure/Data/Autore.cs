using System;
using System.Collections.Generic;

#nullable disable

namespace Infraestructure.Data
{
    public partial class Autore
    {
      
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CiudadProced { get; set; }
        public string Correo { get; set; }


    }
}
