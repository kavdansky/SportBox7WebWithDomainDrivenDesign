namespace SportBox7.Application.Features.Articles.Commands.Create
{
    public class CreateArticleOutputModel
    {
        public CreateArticleOutputModel(int articleId) 
            => this.ArticleId = articleId;

        public int ArticleId { get; }
    }
}
