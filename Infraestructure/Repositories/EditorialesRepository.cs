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
   public class EditorialesRepository : IEditorialesRepository
    {

        public BDLibreriaNexosContext context;
        public EditorialesRepository(BDLibreriaNexosContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Editoriale>> GetEditoriales()
        {
            return context.Editoriales;
        }
        public async Task<Editoriale> GetEditorial(int id)
        {
            return context.Editoriales.Where(x => x.IdEditorial == id).FirstOrDefault();
        }
        public async Task<Editoriale> CreateEditorial(Editoriale editorial)
        {
            context.Editoriales.Add(editorial);
            context.SaveChanges();
            return editorial;
        }
        public async Task<Editoriale> UpdateEditorial(Editoriale editorial)
        {
            context.Entry(editorial).State = EntityState.Modified;
            context.SaveChanges();
            return editorial;
        }
        public async Task<Editoriale> DeleteEditorial(int Id)
        {
            Editoriale editorial = new Editoriale();
            editorial = context.Editoriales.Where(x => x.IdEditorial == Id).FirstOrDefault();
            context.Editoriales.Remove(editorial);
            return editorial;
        }





    }
}
