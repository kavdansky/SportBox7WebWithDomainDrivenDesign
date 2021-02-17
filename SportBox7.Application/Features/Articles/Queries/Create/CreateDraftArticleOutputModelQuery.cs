namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using System.Threading.Tasks;

    public class CreateDraftArticleOutputModelQuery: IRequest<CreateDraftArticleOutputModel>
    {
        private readonly IArticleRepository articleRepository;

        public CreateDraftArticleOutputModelQuery(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<CreateDraftArticleOutputModel> Handle()
        {
            return await CreateDraftArticleOutputModel.CreateAsync(articleRepository);
        }

    }
}
