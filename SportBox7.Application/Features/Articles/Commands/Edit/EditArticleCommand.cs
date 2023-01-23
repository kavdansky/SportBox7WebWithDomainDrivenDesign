namespace SportBox7.Application.Features.Articles.Commands.Edit
{
    using MediatR;
    using SportBox7.Application.Features.Articles.Commands.Common;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Articles.Queries.Edit;
    using SportBox7.Application.Features.Sources;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditArticleCommand: ArticleCommand, IRequest<EditArticleOutputModel>
    {
        public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, EditArticleOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly ISourceRepository sourceRepository;

            public EditArticleCommandHandler(IArticleRepository articleRepository,
                ISourceRepository sourceRepository)
            {
                this.articleRepository = articleRepository;
                this.sourceRepository = sourceRepository;
            }

            public async Task<EditArticleOutputModel> Handle(EditArticleCommand request, CancellationToken cancellationToken)
            {
                var articleToEdit = await this.articleRepository.UpdateArticle(request, sourceRepository.GetSourceByName(request.Source).GetAwaiter().GetResult());
                return new EditArticleOutputModel() { Id = request.Id, ArticleState = articleToEdit.ArticleState };
            }
        }
    }
}
