using BookCatalog.Domain.Entities;
using FluentValidation;

namespace BookCatalog.Domain.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);
            RuleFor(book => book.Author)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);
            RuleFor(book => book.Genre)
                .NotNull()
                .NotEmpty()
                .Length(1, 50);
            RuleFor(book => book.PageCount)
                .NotNull()
                .NotEmpty().WithMessage("Page Count must be greater than 0.")
                .GreaterThan(0).WithMessage("Page Count must be greater than 0.")
                .WithName("Page Count");
        }
    }
}
