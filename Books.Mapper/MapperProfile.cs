using AutoMapper;
using Books.Common.Entities;
using Books.Common.Models.Books;

namespace Books.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}