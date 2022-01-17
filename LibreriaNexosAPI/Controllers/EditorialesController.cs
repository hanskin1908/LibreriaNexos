using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Data;
using Core.Interface;
using AutoMapper;
using Core.Dtos;
using LibreriaNexosAPI.Models;

namespace LibreriaNexosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly BDLibreriaNexosContext _context;
        private readonly IEditorialesService _editorialesService;
        private readonly IMapper _mapper;
        private Mensaje mensaje = new Mensaje();
        public EditorialesController(BDLibreriaNexosContext context, IEditorialesService editorialesservice, IMapper mapper)
        {
            _context = context;
            _editorialesService = editorialesservice;
            _mapper = mapper;
        }

        // GET: api/Editoriales
        [HttpGet]
        public async Task<ActionResult<List<EditorialDto>>> GetEditoriales()
        {

            var editoriales = await _editorialesService.GetEditorialesAll();

            List<EditorialDto> listaEditorialDto = new List<EditorialDto>();
            foreach (var autorlist in editoriales)
            {
                var editorialesdto = _mapper.Map<EditorialDto>(autorlist);
                listaEditorialDto.Add(editorialesdto);
            }

            return listaEditorialDto;
        }

        // GET: api/Editoriales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editoriale>> GetEditoriale(int id)
        {
            var editoriale = await _editorialesService.GetEditorial(id);

            if (editoriale == null)
            {
                mensaje.status = 404;
                mensaje.Message = "No se encontro la editorial con el id " + id + ".";
                return NotFound(mensaje);
            }
            var editorial = _mapper.Map<AutorDto>(editoriale);
            return editoriale;
        }

        // PUT: api/Editoriales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditoriale(int id, EditorialDto editoriale)
        {

            var editoriales = _mapper.Map<Editoriale>(editoriale);
            if (id != editoriale.IdEditorial)
            {
                return BadRequest();
            }


            if (!EditorialeExists(id))
            {
                mensaje.status = 404;
                mensaje.Message = "No existe la editorial ingresada en la base de datos.";
                return NotFound(mensaje);
            }
            else
            {
                try
                {
                    _context.Entry(editoriales).State = EntityState.Modified;
                    await _editorialesService.UpdateEditoriales(editoriales);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }

            }

            mensaje.Message = "La editorial se ha actualizado correctamente.";
            return Ok(mensaje);
        }

        // POST: api/Editoriales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editoriale>> PostEditoriale(EditorialDto editoriale)
        {
            var editorial = _mapper.Map<Editoriale>(editoriale);
            
            if (EditorialeExists(editorial.IdEditorial))
            {
                //Se devuelve status code 409 que indica que genera conflicto el id porque ya existe
                mensaje.status = 409;
                mensaje.Message = "Ya existe la editorial en la base de datos.";
                return Conflict(mensaje);
            }


            try
            {

                await _editorialesService.CreateEditoriales(editorial);
                mensaje.Message = "La editorial se ha guardado correctamente.";
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(mensaje);


            return CreatedAtAction("GetEditoriale", new { id = editoriale.IdEditorial }, editoriale);
        }

        // DELETE: api/Editoriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditoriale(int id)
        {
            var editoriale = await _editorialesService.GetEditorial(id);
            if (editoriale == null)
            {
                return NotFound();
            }


            await _editorialesService.DeleteEditoriales(id);

            return NoContent();
        }

        private bool EditorialeExists(int id)
        {
            return _context.Editoriales.Any(e => e.IdEditorial == id);
        }
    }
}
