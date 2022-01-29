namespace SportBox7.Application.Features.Categories.Commands.Create
{
    using FluentValidation;
    using static Domain.Models.ModelConstants.Category;

    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            this.RuleFor(c => c.CategoryName)
                .MinimumLength(NamesMinLength)
                .MaximumLength(NamesMaxLength)
                .NotEmpty();

            this.RuleFor(c => c.CategoryNameEN)
                .MinimumLength(NamesMinLength)
                .MaximumLength(NamesMaxLength)
                .NotEmpty();
        }
    }
}
