using System;
using System.Collections.Generic;

#nullable disable

namespace Infraestructure.Data
{
    public partial class Editoriale
    {
      

        public int IdEditorial { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int? MaximoLibrosReg { get; set; }


    }
}
