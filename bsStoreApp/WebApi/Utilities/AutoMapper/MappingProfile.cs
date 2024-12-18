using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.Category;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();

            //CreateMap<Book, BookDto>();
            CreateMap<Book, BookDto>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<BookDtoForInsertion, Book>();

            CreateMap<UserForRegistrationDto, User>();


            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();
            CreateMap<CategoryDtoForInsertion, Category>();


        }
    }
}
