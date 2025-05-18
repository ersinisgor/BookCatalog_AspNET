using AutoMapper;
using BookCatalog.Domain.Entities;
using BookCatalog.Infrastructure.Repositories;
using BookCatalog.Shared.DTOs;

namespace BookCatalog.Application.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        public async Task<IEnumerable<BookDTO>> GetBooksAsync(CancellationToken cancellationToken = default)
        {
            var books = await bookRepository.GetBooksAsync(cancellationToken);
            return mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.GetBookByIdAsync(id, cancellationToken);
            return book != null ? mapper.Map<BookDTO>(book) : null;
        }

        public async Task AddBookAsync(CreateBookDTO createDto, CancellationToken cancellationToken = default)
        {
            var book = mapper.Map<Book>(createDto);
            await bookRepository.AddBookAsync(book, cancellationToken);
        }
    }
}
