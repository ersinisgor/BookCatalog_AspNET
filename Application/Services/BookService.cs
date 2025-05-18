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

        public async Task UpdateBookAsync(int id, UpdateBookDTO updateDto, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.GetBookByIdAsync(id, cancellationToken);
            if (book == null)
            {
                throw new ArgumentNullException(nameof(id), $"Book with ID {id} not found.");
            }

            // Update only provided fields
            if (updateDto.Title != null)
                book.Title = updateDto.Title;
            if (updateDto.Author != null)
                book.Author = updateDto.Author;
            if (updateDto.Genre != null)
                book.Genre = updateDto.Genre;
            if (updateDto.PageCount.HasValue)
                book.PageCount = updateDto.PageCount.Value;

            await bookRepository.UpdateBookAsync(book, cancellationToken);
        }
    }
}
