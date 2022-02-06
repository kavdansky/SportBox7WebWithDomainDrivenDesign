namespace SportBox7.Application.Features.Categories.Commands.Edit
{
    using FluentValidation;
    using SportBox7.Application.Features.Categories.Commands.Common;

    public class EditCategoryCommandValidator: AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
            => this.Include(new CategoryCommandBaseModelValidator());
    }
}
