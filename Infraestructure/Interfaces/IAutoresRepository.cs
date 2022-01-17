using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IAutoresRepository
    {
        Task<IEnumerable<Autore>> GetAutores();

        Task<Autore> GetAutor(int id);

        Task<Autore> CreateAutor(Autore autor);

        Task<Autore> UpdateAutor(Autore autor);

        Task<Autore> DeleteAutor(int Id);

    }
}
