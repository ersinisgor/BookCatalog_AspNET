using BookCatalog.Shared.DTOs;

namespace BookCatalog.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync(CancellationToken cancellationToken = default);
    }
}
