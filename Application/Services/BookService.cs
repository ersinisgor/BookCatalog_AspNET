using AutoMapper;
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
    }
}
