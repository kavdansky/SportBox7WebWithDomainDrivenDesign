namespace SportBox7.Infrastructure.TextHandling
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Domain.Models.Articles;
    using System;

    public class TextManipulationService : ITextManipulationService
    {
        private const string PassedYearsTemplate = "{dd}";

        public Article SetPassedYearsInText(Article article)
        {

            int passedYears = DateTime.Now.Year - article.TargetDate.Year;

            article.UpdateH1Tag(article.H1Tag.Replace(PassedYearsTemplate, passedYears.ToString()));
            article.UpdateBody(article.Body.Replace(PassedYearsTemplate, passedYears.ToString()));
            article.UpdateTitle(article.Title.Replace(PassedYearsTemplate, passedYears.ToString()));

            return article;
        }
    }
}
