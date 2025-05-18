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

        public async Task<Book> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Books.FindAsync(id, cancellationToken);
        }

        public async Task AddBookAsync(Book book, CancellationToken cancellationToken = default)
        {
            await context.Books.AddAsync(book, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken = default)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
