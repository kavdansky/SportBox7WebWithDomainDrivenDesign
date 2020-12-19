﻿namespace SportBox7.Application.Features.Articles.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator(IArticleRepository articleRepository) 
            => this.Include(new ArticleCommandValidator<CreateArticleCommand>(articleRepository));
    }
}
