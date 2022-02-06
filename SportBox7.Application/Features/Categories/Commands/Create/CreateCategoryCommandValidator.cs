namespace SportBox7.Application.Features.Categories.Commands.Create
{
    using FluentValidation;
    using SportBox7.Application.Features.Categories.Commands.Common;

    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        => this.Include(new CategoryCommandBaseModelValidator());
    }
}
