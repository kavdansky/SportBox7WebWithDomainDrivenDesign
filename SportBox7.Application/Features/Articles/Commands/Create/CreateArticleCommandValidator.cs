namespace SportBox7.Application.Features.Articles.Commands.Create
{
    using Common;
    using FluentValidation;
    using SportBox7.Application.Features.Articles.Contrcts;

    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator(IArticleRepository articleRepository) 
            => this.Include(new ArticleCommandValidator(articleRepository));
    }
}
