namespace SportBox7.Infrastructure.TextHandling
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Domain.Models.Articles;
    using System;

    public class TextManipulationService : ITextManipulationService
    {
        public Article SetPassedYearsInText(Article article)
        {
            string passedYearsTemplate = "{dd}";
            int passedYears = DateTime.Now.Year - article.TargetDate.Year;

            article.UpdateH1Tag(article.H1Tag.Replace(passedYearsTemplate, passedYears.ToString()));
            article.UpdateBody(article.Body.Replace(passedYearsTemplate, passedYears.ToString()));
            article.UpdateTitle(article.Title.Replace(passedYearsTemplate, passedYears.ToString()));

            return article;
        }
    }
}
