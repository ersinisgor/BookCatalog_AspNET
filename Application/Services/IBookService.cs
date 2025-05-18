using BookCatalog.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync(CancellationToken cancellationToken = default);
        Task AddBookAsync([FromForm] CreateBookDTO createDto, CancellationToken cancellationToken = default);
    }
}
