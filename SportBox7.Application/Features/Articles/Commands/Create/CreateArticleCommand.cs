namespace SportBox7.Application.Features.Articles.Commands.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Commands.Common;
    using SportBox7.Application.Features.Articles.Contrcts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Sources;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Domain.Factories.Articles;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using System.IO;

    public class CreateArticleCommand : ArticleCommand, IRequest<CreateArticleOutputModel>
    {
        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;
            private readonly IArticleRepository articleRepository;
            private readonly IArticleFactory articleFactory;
            private readonly ISourceRepository sourceRepository;
            private readonly ICategoryRepository categoryRepository;
            private IHostingEnvironment hostingEnvironment;

            public CreateArticleCommandHandler(
                ICurrentUser currentUser,
                IEditorRepository editorRepository,
                IArticleRepository articleRepository,
                IArticleFactory articleFactory,
                ISourceRepository sourceRepository,
                ICategoryRepository categoryRepository,
                IHostingEnvironment hostingEnvironment)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
                this.articleRepository = articleRepository;
                this.articleFactory = articleFactory;
                this.sourceRepository = sourceRepository;
                this.categoryRepository = categoryRepository;
                this.hostingEnvironment = hostingEnvironment;
            }

            public async Task<CreateArticleOutputModel> Handle(
                CreateArticleCommand request,
                CancellationToken cancellationToken)
            {
                var editor = await this.editorRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var category = await this.categoryRepository.GetCategoryByName(
                    request.Category);

                var source = await sourceRepository.GetSourceByName(request.Source);

                var webRootPath = hostingEnvironment.ContentRootPath;
                webRootPath = webRootPath.Replace("Startup", "Web")+ "\\wwwroot";
                var imageUrl = request.ImageUrl;
                var imageName = Guid.NewGuid();

                if (request.Image != null)
                {
                    imageUrl = @$"{webRootPath}/Images/{imageName}.jpg";

                    using (var fileStream = new FileStream(imageUrl, FileMode.Create))
                    {
                        request.Image.CopyTo(fileStream);
                    }
                    byte[] myBinaryImage = File.ReadAllBytes(imageUrl);
                    File.WriteAllBytes(imageUrl, myBinaryImage);

                }

                var article = articleFactory
                    .WithTitle(request.Title)
                    .WithBody(request.Body)
                    .WithH1Tag(request.H1Tag)
                    .WithImageUrl(imageUrl)
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
