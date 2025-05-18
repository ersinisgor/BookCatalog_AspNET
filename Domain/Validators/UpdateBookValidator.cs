using BookCatalog.Shared.DTOs;
using FluentValidation;

namespace BookCatalog.Domain.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDTO>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().When(x => x.Title != null).WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(50).When(x => x.Title != null).WithMessage("{PropertyName} must be less than {MaxLength} characters.");

            RuleFor(x => x.Author)
                .NotEmpty().When(x => x.Author != null).WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(50).When(x => x.Author != null).WithMessage("{PropertyName} must be less than {MaxLength} characters.");

            RuleFor(x => x.Genre)
                .NotEmpty().When(x => x.Genre != null).WithMessage("{PropertyName} cannot be empty.")
                .MaximumLength(50).When(x => x.Genre != null).WithMessage("{PropertyName} must be less than {MaxLength} characters.");

            RuleFor(x => x.PageCount)
                .GreaterThan(0).When(x => x.PageCount.HasValue).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}