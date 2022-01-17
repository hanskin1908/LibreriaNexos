using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IEditorialesRepository
    {
        Task<IEnumerable<Editoriale>> GetEditoriales();

        Task<Editoriale> GetEditorial(int id);

        Task<Editoriale> CreateEditorial(Editoriale editorial);

        Task<Editoriale> UpdateEditorial(Editoriale editorial);

        Task<Editoriale> DeleteEditorial(int Id);


    }
}
