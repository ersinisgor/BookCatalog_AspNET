using BookCatalog.Domain.Entities;
using BookCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext context) : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken = default)
        {
            return await context.Books.ToListAsync(cancellationToken);
        }
    }
}
