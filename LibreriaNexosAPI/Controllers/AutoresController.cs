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
    public class AutoresController : ControllerBase
    {
        private readonly BDLibreriaNexosContext _context;
        private readonly IAutoresService _AutoresService;
        private readonly IMapper _mapper;
        private Mensaje mensaje = new Mensaje();

        public AutoresController(BDLibreriaNexosContext context,IAutoresService autoresservice, IMapper mapper)
        {
            _context = context;
            _AutoresService = autoresservice;
            _mapper = mapper;
        }

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores()
        {
            
           var autores = await _AutoresService.GetAutoresAll();
            List<AutorDto> listaautorDto = new List<AutorDto>();
            foreach (var autorlist in autores)
            {
                var autoresdto = _mapper.Map<AutorDto>(autorlist);
                listaautorDto.Add(autoresdto);
            }

            return listaautorDto;

        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutor(int id)
        {
            var autore = await _AutoresService.GetAutor(id); 
               

            if (autore == null)
            {
                mensaje.status = 404;
                mensaje.Message = "No se encontro el autor con el id " + id + ".";
                return NotFound(mensaje);
                
            }
            var autor = _mapper.Map<AutorDto>(autore);
            return autor;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutore(int id, AutorDto autordto)
        {
            var autores = _mapper.Map<Autore>(autordto);

            if (id != autordto.IdAutor)
            {
                return BadRequest();
            }

            if (!AutoreExists(id))
            {
                return NotFound();
            }
            else
            {
                try
                {

                    _context.Entry(autordto).State = EntityState.Modified;
                    await _AutoresService.UpdateAutores(autores);
                }catch(Exception e)
                {
                    return BadRequest(e);
                }
            }

            mensaje.Message = "El autor se ha actualizado correctamente.";
            return Ok(mensaje);





        }

        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autore>> PostAutore(AutorDto autore)
        {
            var autor = _mapper.Map<Autore>(autore);
            if (AutoreExists(autor.IdAutor))
            {
                //Se devuelve status code 409 que indica que genera conflicto el id porque ya existe
                mensaje.status = 409;
                mensaje.Message = "Ya existe el autor en la base de datos.";
                return Conflict(mensaje);
            }
            await _AutoresService.CreateAutor(autor);
         
            try
            {
                mensaje.Message = "El autor se ha guardado correctamente.";
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(mensaje);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutore(int id)
        {
            var autore = await _AutoresService.GetAutor(id);
            if (autore == null)
            {
                return NotFound();
            }

            await _AutoresService.DeleteAutor(id);
            

            return NoContent();
        }

        private bool AutoreExists(int id)
        {
            return _context.Autores.Any(e => e.IdAutor == id);
        }
    }
}
