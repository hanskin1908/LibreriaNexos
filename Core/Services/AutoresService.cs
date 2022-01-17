using Core.Interface;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AutoresService : IAutoresService
    {

        public IAutoresRepository autoresRepository;
        public AutoresService(IAutoresRepository autoresRepository)
        {
            this.autoresRepository = autoresRepository;
        }

        public async Task<Autore> CreateAutor(Autore autores)
        {
            return await this.autoresRepository.CreateAutor(autores);
        }

        public Task<Autore> DeleteAutor(int id)
        {
            return this.autoresRepository.DeleteAutor(id);
        }

        public async Task<Autore> GetAutor(int id)
        {
            return await this.autoresRepository.GetAutor(id);
        }



        public async Task<IEnumerable<Autore>> GetAutoresAll()
        {
            return await autoresRepository.GetAutores();
        }



        public async Task<Autore> UpdateAutores(Autore autores)
        {
            return await this.autoresRepository.UpdateAutor(autores);
        }
    }
}



