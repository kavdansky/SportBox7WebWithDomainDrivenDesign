namespace SportBox7.Application.Features.Categories.Commands.Common
{
    using FluentValidation;
    using static Domain.Models.ModelConstants.Category;

    public class CategoryCommandBaseModelValidator: AbstractValidator<CategoryCommandBaseModel>
    {
        public CategoryCommandBaseModelValidator()
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
