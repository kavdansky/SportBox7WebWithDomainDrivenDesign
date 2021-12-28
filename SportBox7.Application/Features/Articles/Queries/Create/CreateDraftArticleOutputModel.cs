namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Sources;
    using System.Threading.Tasks;

    public class CreateDraftArticleOutputModel: CreateDraftArticleModel
    {
       
        public CreateDraftArticleOutputModel()
        {
        }

        private async Task<CreateDraftArticleOutputModel> InitializeAsync(IArticleRepository articleRepository, ISourceRepository sourceRepository)
        {
            this.Categories = await articleRepository.GetMenuCategories();
            this.Sources = await sourceRepository.GetSources();
            return this;
        }

        public static Task<CreateDraftArticleOutputModel> CreateAsync(IArticleRepository articleRepository, ISourceRepository sourceRepository)
        {
            var outputModel = new CreateDraftArticleOutputModel();
            return outputModel.InitializeAsync(articleRepository, sourceRepository);
        }

    }
}
