namespace SportBox7.Application.Features.Articles.Queries.Edit
{
    using AutoMapper;
    using MediatR;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Sources;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditArticleOutputModelQuery: IRequest<EditArticleOutputModel>
    {
        public int Id { get; set; }

        public class EditArticleOutputModelQueryHandler : IRequestHandler<EditArticleOutputModelQuery, EditArticleOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ISourceRepository sourceRepository;
            private readonly IMapper mapper;
            public EditArticleOutputModelQueryHandler(IArticleRepository articleRepository, ISourceRepository sourceRepository, IMapper mapper)
            {
                this.articleRepository = articleRepository;
                this.sourceRepository = sourceRepository;
                this.mapper = mapper;
            }

            public async Task<EditArticleOutputModel> Handle(EditArticleOutputModelQuery request, CancellationToken cancellationToken)
            {
                var article = await articleRepository.GetArticleObjectById(request.Id);
                var model = this.mapper.Map<EditArticleOutputModel>(article);
                model.Source = article.Source.SourceName;

                model.Categories = await articleRepository.GetMenuCategories();
                model.Sources = await sourceRepository.GetSources();
                return model;
            }

          
        }

        

        

    }
}
