namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Sources;
    using System.Threading.Tasks;

    public class CreateDraftArticleOutputModelQuery: IRequest<CreateDraftArticleOutputModel>
    {
        private readonly IArticleRepository articleRepository;
        private readonly ISourceRepository sourceRepository;

        public CreateDraftArticleOutputModelQuery(IArticleRepository articleRepository, ISourceRepository sourceRepository)
        {
            this.articleRepository = articleRepository;
            this.sourceRepository = sourceRepository;
        }

        public async Task<CreateDraftArticleOutputModel> Handle()
        {
            return await CreateDraftArticleOutputModel.CreateAsync(articleRepository, sourceRepository);
        }

    }
}
