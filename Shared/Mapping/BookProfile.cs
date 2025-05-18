using AutoMapper;
using BookCatalog.Domain.Entities;
using BookCatalog.Shared.DTOs;

namespace BookCatalog.Shared.Mapping
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<Book, UpdateBookDTO>();
        }
    }
}
