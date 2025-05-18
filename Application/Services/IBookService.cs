using BookCatalog.Shared.DTOs;

namespace BookCatalog.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync(CancellationToken cancellationToken = default);
        Task<BookDTO> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddBookAsync(CreateBookDTO createDto, CancellationToken cancellationToken = default);

        Task UpdateBookAsync(int id, UpdateBookDTO updateDto, CancellationToken cancellationToken = default);
    }
}
