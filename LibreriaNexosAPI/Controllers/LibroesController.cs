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
    public class LibroesController : ControllerBase
    {
        private readonly BDLibreriaNexosContext _context;
        private readonly ILibrosService _librosService;
        private readonly IEditorialesService _Editorialservice;
        private readonly IMapper _mapper;
        private Mensaje mensaje = new Mensaje();

        public LibroesController(BDLibreriaNexosContext context,ILibrosService librosService, IMapper mapper, IEditorialesService editorialservice)
        {
            _context = context;
            _librosService = librosService;
            _mapper = mapper;
            _Editorialservice = editorialservice;
        }

        // GET: api/Libroes
        [HttpGet]
        public async Task<ActionResult<LibrosResponseDto>> GetLibros()
        {
            try
            {
                var libros = await _librosService.GetLibrosAll();
               


                if (libros  == null)
                {
                    mensaje.status = 404;
                    mensaje.Message = "No se encontraron libros";
                    return NotFound(mensaje);
                }
                else
                {

                    return Ok(libros);
                }

               
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
          
          
        }

        // GET: api/Libroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetLibro(int id)
        {
            var libro = await  _librosService.GetLibro(id);

            if (libro == null)
            {
                return NotFound();
            }
            var librodto = _mapper.Map<LibroDto>(libro);
            return librodto;
        }

        // PUT: api/Libroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, LibroDto librodto)
        {
            var libro = _mapper.Map<Libro>(librodto);
           
            if (id != librodto.Idisbn)
            {
                return BadRequest();
            }

           

            if (!AutorExists(libro.IdAutor))
            {
                mensaje.status = 404;
                mensaje.Message = "El autor no esta registrado.";
                return NotFound(mensaje);
            }
            else if (!EditorialExists(libro.IdEditorial))
            {
                mensaje.status = 404;
                mensaje.Message = "La editorial no esta registrada.";
                return NotFound(mensaje);
            }

           
            try
            {
                var editorial = await _Editorialservice.GetEditorial((int)librodto.IdEditorial);
                var editorialdto =  _mapper.Map<EditorialDto>(editorial);

                var  libros= await _librosService.GetLibros();
                int cantidadlibroseditorial = libros.Count + 1;

                if (editorialdto.MaximoLibrosReg == cantidadlibroseditorial)
                {
                    mensaje.status = 400;
                    mensaje.Message = "No es posible actualizar el libro, se alcanzó el máximo permitido.";
                    return BadRequest(mensaje);
                }
                else
                {
                    

                    await _librosService.UpdateLibro(libro);
                    mensaje.Message = "El libro se ha actualizado correctamente.";
                    return Ok(mensaje);
                }


            
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

           
        }

        // POST: api/Libroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(LibroDto librodto)
        {
            var libro = _mapper.Map<Libro>(librodto);
  

            if (LibroExists(libro.Idisbn))
            {
                mensaje.status = 409;
                mensaje.Message = "Ya existe el libro en la base de datos.";
                return Conflict(mensaje);
            }
            if (!AutorExists(libro.IdAutor))
            {
                mensaje.status = 404;
                mensaje.Message = "El autor no esta registrado.";
                return NotFound(mensaje);
            }
            //Se hace la validación para comprobar que la editorial este registrada
            else if (!EditorialExists(libro.IdEditorial))
            {
                mensaje.status = 404;
                mensaje.Message = "La editorial no esta registrada.";
                return NotFound(mensaje);
            }
            try
            {
                var editorial = await _Editorialservice.GetEditorial(librodto.IdEditorial);
                var editorialdto = _mapper.Map<EditorialDto>(editorial);

                var libros = await _librosService.GetLibros();
                int cantidadlibroseditorial = libros.Count + 1;

                if (cantidadlibroseditorial >  editorialdto.MaximoLibrosReg )
                {
                    mensaje.status = 409;
                    mensaje.Message = "No es posible registrar el libro, se alcanzó el máximo permitido.";
                    return Conflict(mensaje);
                }
                else
                {
                    await _librosService.CreateLibro(libro);
                    mensaje.Message = "El libro se ha guardado correctamente.";
                    return Ok(mensaje);
                }
           



            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
                 


                return CreatedAtAction("GetLibro", new { id = libro.Idisbn }, libro);
        }

        // DELETE: api/Libroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _librosService.GetLibro(id) ;
            if (libro == null)
            {
                mensaje.status = 409;
                mensaje.Message = "No se encontro el libro.";
                return NotFound(mensaje);
            }

       
            await _librosService.DeleteLibro(id);

            return NoContent();
        }

        [HttpGet("find/{find}")]
        public async Task<ActionResult<LibrosResponseDto>> GetLibroByNombres(string find)
        {
            
            var libros = await _librosService.GetLibroByNombres(find);
           
            if (libros == null)
            {
                return NotFound();
            }
            var librodto = _mapper.Map<List<LibrosResponseDto>>(libros);
            return Ok(libros);
        }

        private bool AutorExists(int? id)
        {
            return _context.Autores.Any(a => a.IdAutor == id);
        }

        private bool LibroExists(int? id)
        {
            return _context.Libros.Any(e => e.Idisbn == id);
        }

        private bool EditorialExists(int? id)
        {
            return _context.Editoriales.Any(e => e.IdEditorial == id);
        }
    }
}
