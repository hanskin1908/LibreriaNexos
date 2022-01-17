using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ILibrosService
    {
        Task<Libro> CreateLibro(Libro libros);

        Task<Libro> DeleteLibro(int id);

        Task<Libro> GetLibro(int id);

        Task<List<Libro>> GetLibros();

        Task<Libro> UpdateLibro(Libro libros);

        Task<dynamic> GetLibroByNombres(string Busqueda);

        Task<dynamic> GetLibrosAll();

    }
}
