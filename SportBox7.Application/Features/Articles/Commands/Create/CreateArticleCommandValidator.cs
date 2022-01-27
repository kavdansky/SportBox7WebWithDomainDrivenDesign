namespace SportBox7.Application.Features.Articles.Commands.Create
{
    using Common;
    using FluentValidation;
    using SportBox7.Application.Features.Categories.Contracts;

    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator(ICategoryRepository categoryRepository) 
            => this.Include(new ArticleCommandValidator(categoryRepository));
    }
}
