using BookCatalog.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync(CancellationToken cancellationToken = default);
        Task<BookDTO> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddBookAsync(CreateBookDTO createDto, CancellationToken cancellationToken = default);
    }
}
