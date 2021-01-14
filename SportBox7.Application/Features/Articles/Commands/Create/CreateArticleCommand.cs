using MediatR;
using SportBox7.Application.Contracts;
using SportBox7.Application.Features.Articles.Commands.Common;
using SportBox7.Application.Features.Articles.Contrcts;
using SportBox7.Application.Features.Editors;
using SportBox7.Domain.Factories.Articles;
using System;
namespace SportBox7.Application.Features.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateArticleCommand : ArticleCommand<CreateArticleCommand>, IRequest<CreateArticleOutputModel>
    {
        public class CreateCreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;
            private readonly IArticleRepository articleRepository;
            private readonly IArticleFactory articleFactory;

            public CreateCreateArticleCommandHandler(
                ICurrentUser currentUser,
                IEditorRepository editorRepository,
                IArticleRepository articleRepository,
                IArticleFactory articleFactory)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
                this.articleRepository = articleRepository;
                this.articleFactory = articleFactory;
            }

            public async Task<CreateArticleOutputModel> Handle(
                CreateArticleCommand request,
                CancellationToken cancellationToken)
            {
                var editor = await this.editorRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var category = await this.articleRepository.GetCategory(
                    request.Category,
                    cancellationToken);

                var article = articleFactory
                    .WithTitle(request.Title)
                    .WithBody(request.Body)
                    .WithH1Tag(request.H1Tag)
                    .WithImageUrl(request.ImageUrl)
                    .WithSeoUrl(request.SeoUrl)
                    .WithMetaDescription(request.MetaDescription)
                    .WithMetaKeywords(request.MetaKeywords)
                    .WithCategory(category.CategoryName, category.CategoryNameEN)
                    .WithArticleType((Domain.Models.Articles.Enums.ArticleType)request.ArticleType)
                    .WithTargetDate(DateTime.Parse(request.TargetDate))
                    .Build();

                editor.AddArticle(article);

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateArticleOutputModel(article.Id);
            }
        }
    }
}
