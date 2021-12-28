namespace SportBox7.Application.Features.Articles.Commands.Common
{
    using System;
    using FluentValidation;
    using static Domain.Models.ModelConstants.Common;
    using static Domain.Models.ModelConstants.Article;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Application.Features.Articles.Contrcts;

    public class ArticleCommandValidator<TCommand> : AbstractValidator<ArticleCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ArticleCommandValidator(IArticleRepository articleRepository)
        {
            this.RuleFor(c => c.Title)
                .MinimumLength(TitleMinLength)
                .MaximumLength(TitleMaxLength)
                .NotEmpty();

            this.RuleFor(c => c.Body)
                .MinimumLength(BodyMinLength)
                .MaximumLength(BodyMaxLength)
                .NotEmpty();

            this.RuleFor(c => c.Category)
                .MustAsync(async (category, token) => await articleRepository
                    .GetCategoryByName(category) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            this.RuleFor(c => c.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(c => c.H1Tag)
                .MinimumLength(H1MinLength)
                .MaximumLength(H1MaxLength)
                .NotEmpty();

            this.RuleFor(c => c.SeoUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(c => c.MetaDescription)
               .MinimumLength(MetatagsMinLength)
               .MaximumLength(MetatagsMaxLength)
               .NotEmpty();

            this.RuleFor(c => c.MetaKeywords)
               .MinimumLength(MetatagsMinLength)
               .MaximumLength(MetatagsMaxLength)
               .NotEmpty();


            this.RuleFor(c => c.ArticleType)
                .Must(ContainArticleType)
                .WithMessage("'Transmission Type' is not valid.");

            this.RuleFor(s => s.TargetDate)
            .Must(BeAValidDate)
            .WithMessage("Invalid date/time");
        }

        private bool BeAValidDate(string value)
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            return DateTime.TryParse(value, out DateTime date);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }

        private bool ContainArticleType(int value)
        {
            bool isInType = false;
            if (Enum.IsDefined(typeof(ArticleType), value))
                isInType = true;

            return isInType;
        }

    }
}
