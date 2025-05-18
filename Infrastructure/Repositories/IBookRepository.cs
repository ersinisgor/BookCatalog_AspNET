using BookCatalog.Domain.Entities;

namespace BookCatalog.Infrastructure.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken = default);
        Task<Book> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddBookAsync(Book book, CancellationToken cancellationToken = default);

        Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default);
    }
}
