using AutoMapper;
using BookShop.Core.DTOs;
using BookShop.Core.Entities;

namespace BookShop.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Escritor
            CreateMap<Writer, DtoWriter>();
            CreateMap<DtoWriter, Writer>();

            //Pais
            CreateMap<Country, DtoCountry>();
            CreateMap<DtoCountry, Country>();

            //Ciudad
            CreateMap<Cities, DtoCity>();
            CreateMap<DtoCity, Cities>();

            //Libros
            CreateMap<Book, DtoBook>();
            CreateMap<DtoBook, Book>();
        }
    }
}
