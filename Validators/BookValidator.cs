using BookCatalog.Models;
using FluentValidation;

namespace BookCatalog.Validations
{
    public class BookValidator: AbstractValidator<Book>
    {
        public BookValidator() {
            RuleFor(book => book.Title)
                .NotNull()
                .NotEmpty()
                .Length(1,50);
            RuleFor(book => book.Author)
                .NotNull()
                .NotEmpty()
                .Length(1,50);
            RuleFor(book => book.Genre)
                .NotNull()
                .NotEmpty()
                .Length(1,50);
            RuleFor(book => book.PageCount)
                .NotNull()
                .GreaterThan(0)
                .WithName("Page Count");
        }
    }
}
