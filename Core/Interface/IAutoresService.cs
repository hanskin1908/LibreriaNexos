using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IAutoresService
    {
        Task<Autore> CreateAutor(Autore autores);
        Task<Autore> DeleteAutor(int id);

        Task<Autore> GetAutor(int id);

        Task<IEnumerable<Autore>> GetAutoresAll();

         Task<Autore> UpdateAutores(Autore autores);
    }
}
