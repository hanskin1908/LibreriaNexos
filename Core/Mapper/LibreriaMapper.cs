using AutoMapper;
using Core.Dtos;
using Infraestructure.Data;
//using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class LibreriaMapper : Profile
    {
        public LibreriaMapper()
        {
            CreateMap<Libro, LibroDto>().ReverseMap();
            CreateMap<dynamic,List<LibrosResponseDto>>().ReverseMap();
            CreateMap<Autore, AutorDto>().ReverseMap();
            CreateMap<Editoriale, EditorialDto>().ReverseMap();
        }
    }
}
