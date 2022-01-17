using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IEditorialesService
    {
        Task<Editoriale> CreateEditoriales(Editoriale editoriales);

        Task<Editoriale> DeleteEditoriales(int id);

        Task<Editoriale> GetEditorial(int EditorialeId);

        Task<IEnumerable<Editoriale>> GetEditorialesAll();

        Task<Editoriale> UpdateEditoriales(Editoriale editoriales);
    }
}
