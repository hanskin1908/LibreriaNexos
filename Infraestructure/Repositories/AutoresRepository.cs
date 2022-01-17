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
   public class AutoresRepository : IAutoresRepository
    {

        public BDLibreriaNexosContext context;
        public AutoresRepository(BDLibreriaNexosContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Autore>> GetAutores()
        {
            return await context.Autores.ToListAsync();
        }
        public async Task<Autore> GetAutor(int id)
        {
            return context.Autores.Where(x => x.IdAutor == id).FirstOrDefault();
        }
        public async Task<Autore> CreateAutor(Autore autor)
        {
            context.Autores.Add(autor);
            context.SaveChanges();
            return autor;
        }
        public async Task<Autore> UpdateAutor(Autore autor)
        {
            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return autor;
        }
        public async Task<Autore> DeleteAutor(int Id)
        {
            Autore autor = new Autore();
            autor = context.Autores.Where(x => x.IdAutor == Id).FirstOrDefault();
            context.Autores.Remove(autor);
            return autor;
        }





    }
}
