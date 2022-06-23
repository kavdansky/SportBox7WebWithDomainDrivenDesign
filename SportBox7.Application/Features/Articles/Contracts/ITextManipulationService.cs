namespace SportBox7.Application.Features.Articles.Contracts
{
    using SportBox7.Domain.Models.Articles;

    public interface ITextManipulationService
    {
        public Article SetPassedYearsInText(Article article);
    }
}
