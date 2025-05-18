using AutoMapper;
using BookCatalog.Domain.Entities;
using BookCatalog.Infrastructure.Repositories;
using BookCatalog.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Application.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        public async Task<IEnumerable<BookDTO>> GetBooksAsync(CancellationToken cancellationToken = default)
        {
            var books = await bookRepository.GetBooksAsync(cancellationToken);
            return mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task AddBookAsync([FromForm] CreateBookDTO createDto, CancellationToken cancellationToken = default)
        {
            var book = mapper.Map<Book>(createDto);
            await bookRepository.AddBookAsync(book, cancellationToken);
        }
    }
}
