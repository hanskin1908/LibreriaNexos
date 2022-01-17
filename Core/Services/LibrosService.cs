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
  public  class LibrosService :ILibrosService
    {
        public ILibrosRepository librosRepository;
        public LibrosService(ILibrosRepository librosRepository)
        {
            this.librosRepository = librosRepository;
        }

        public async Task<Libro> CreateLibro(Libro libros)
        {
            return await this.librosRepository.CreateLibro(libros);
        }

        public async Task<Libro> DeleteLibro(int id)
        {
            return await this.librosRepository.DeleteLibro(id);
        }

        public async Task<Libro> GetLibro(int id)
        {
            return await this.librosRepository.GetLibro(id);
        }

        public async Task<List<Libro>> GetLibros()
        {
            var libros = this.librosRepository.GetLibros();
            return await libros;
        }

        public async Task<Libro> UpdateLibro(Libro libros)
        {
            return await this.librosRepository.UpdateLibro(libros);
        }

        public async Task<dynamic> GetLibroByNombres(string Busqueda)
        {
            return await this.librosRepository.GetLibroByNombres(Busqueda);
        }

        public async Task<dynamic> GetLibrosAll()
        {
            return await this.librosRepository.GetLibrosAll();
        }

    }
}
