using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface ILibrosRepository
    {
        Task<List<Libro>> GetLibros();
        Task<Libro> GetLibro(int id);

        Task<Libro> CreateLibro(Libro libros);

        Task<Libro> UpdateLibro(Libro libros);
        Task<Libro> DeleteLibro(int Id);

        Task<dynamic> GetLibroByNombres(string Busqueda);
        Task<dynamic> GetLibrosAll();
    }
}
