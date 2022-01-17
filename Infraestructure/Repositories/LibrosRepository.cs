using Infraestructure.Data;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class LibrosRepository : ILibrosRepository
    {
        public BDLibreriaNexosContext context;
     
        public LibrosRepository(BDLibreriaNexosContext context )
        {
            this.context = context;
          
        }
        public async Task<List<Libro>> GetLibros()
        {
            var libros = context.Libros.AsNoTracking().ToListAsync();
            return await libros;
        }

        public async Task<dynamic> GetLibrosAll()
        {
            var Librosall =  from l in context.Libros
                                        join a in context.Autores on l.IdAutor equals a.IdAutor
                                        join e in context.Editoriales on l.IdEditorial equals e.IdEditorial
                                        select new { NombreAutor = a.Nombre, l.Titulo, Anio = l.Anio, l.NumeroPaginas, Editorial = e.Nombre, l.Genero, l.Idisbn };
            return Librosall.ToList();
        }


        public async Task<Libro> GetLibro(int id)
        {
            return context.Libros.Where(x => x.Idisbn == id).FirstOrDefault();
        }
        public async Task<Libro> CreateLibro(Libro libros)
        {
            context.Libros.Add(libros);
            context.SaveChanges();
            return libros;
        }
        public async Task<Libro> UpdateLibro(Libro libros)
        {
            context.Entry(libros).State = EntityState.Modified;
            context.SaveChanges();
      
            return libros;
        }
        public async Task<Libro> DeleteLibro(int Id)
        {
            Libro libros = new Libro();
            libros = context.Libros.Where(x => x.Idisbn == Id).FirstOrDefault();
            context.Libros.Remove(libros);
            context.SaveChanges();
            return libros;
        }


        public async Task<dynamic> GetLibroByNombres(string Busqueda)
        {
            var query = from l in context.Libros
                        join a in context.Autores on l.IdAutor equals a.IdAutor
                        join e in context.Editoriales on l.IdEditorial equals e.IdEditorial
                        where a.Nombre.Contains(Busqueda) || l.Titulo.Contains(Busqueda) || l.Anio.ToString().Contains(Busqueda) || e.Nombre.Contains(Busqueda)
                        select new { NombreAutor = a.Nombre, l.Titulo, Anio = l.Anio, l.NumeroPaginas, Editorial = e.Nombre,l.Genero,l.Idisbn };

            return  query.ToList();
        }




    }
}
