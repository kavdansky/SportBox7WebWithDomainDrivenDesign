using SportBox7.Application.Features.Articles.Contrcts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Articles.Queries.Create
{
    public class CreateDraftArticleOutputModel
    {
        public CreateDraftArticleOutputModel()
        {
            this.Article = new CreateDraftArticleModel();
        }

        public CreateDraftArticleModel Article { get; set; }

        private async Task<CreateDraftArticleOutputModel> InitializeAsync(IArticleRepository articleRepository)
        {
            this.Article.Categories = await articleRepository.GetMenuCategories();
            return this;
        }

        public static Task<CreateDraftArticleOutputModel> CreateAsync(IArticleRepository articleRepository)
        {
            var outputModel = new CreateDraftArticleOutputModel();
            return outputModel.InitializeAsync(articleRepository);
        }

    }
}
