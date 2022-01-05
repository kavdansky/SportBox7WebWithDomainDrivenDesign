namespace SportBox7.Application.Features.Articles.Commands.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Commands.Common;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Sources;
    using SportBox7.Domain.Factories.Articles;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateArticleCommand : ArticleCommand, IRequest<CreateArticleOutputModel>
    {
        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;
            private readonly IArticleRepository articleRepository;
            private readonly IArticleFactory articleFactory;
            private readonly ISourceRepository sourceRepository;

            public CreateArticleCommandHandler(
                ICurrentUser currentUser,
                IEditorRepository editorRepository,
                IArticleRepository articleRepository,
                IArticleFactory articleFactory,
                ISourceRepository sourceRepository)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
                this.articleRepository = articleRepository;
                this.articleFactory = articleFactory;
                this.sourceRepository = sourceRepository;
            }

            public async Task<CreateArticleOutputModel> Handle(
                CreateArticleCommand request,
                CancellationToken cancellationToken)
            {
                var editor = await this.editorRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var category = await this.articleRepository.GetCategoryByName(
                    request.Category);

                var source = await sourceRepository.GetSourceByName(request.Source);

                var article = articleFactory
                    .WithTitle(request.Title)
                    .WithBody(request.Body)
                    .WithH1Tag(request.H1Tag)
                    .WithImageUrl(request.ImageUrl)
                    .WithSeoUrl(request.SeoUrl)
                    .WithMetaDescription(request.MetaDescription)
                    .WithMetaKeywords(request.MetaKeywords)
                    .WithCategory(category)
                    .WithArticleType((Domain.Models.Articles.Enums.ArticleType)request.ArticleType)
                    .WithTargetDate(DateTime.Parse(request.TargetDate))
                    .WithSource(source)
                    
                    .Build();

                editor.AddArticle(article);

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateArticleOutputModel(article.Id);
            }
        }
    }
}
