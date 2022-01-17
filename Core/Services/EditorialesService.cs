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
    public class EditorialesService : IEditorialesService
    {
        public IEditorialesRepository editorialesRepository;
        public EditorialesService(IEditorialesRepository editorialesRepository)
        {
            this.editorialesRepository = editorialesRepository;
        }

        public Task<Editoriale> CreateEditoriales(Editoriale editoriales)
        {
            return this.editorialesRepository.CreateEditorial(editoriales);
        }

        public async Task<Editoriale> DeleteEditoriales(int id)
        {
            return await this.editorialesRepository.DeleteEditorial(id);
        }

        public async Task<Editoriale> GetEditorial(int EditorialeId)
        {
            return await editorialesRepository.GetEditorial(EditorialeId);
        }



        public async Task<IEnumerable<Editoriale>> GetEditorialesAll()
        {
            return await editorialesRepository.GetEditoriales();
        }

        public async Task<Editoriale> UpdateEditoriales(Editoriale editoriales)
        {
            return await this.editorialesRepository.UpdateEditorial(editoriales);
        }



    }
}
