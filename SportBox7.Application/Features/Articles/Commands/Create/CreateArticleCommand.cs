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
    using System.IO;
    using SportBox7.Application.Features.Articles.Contracts;
    using Microsoft.AspNetCore.Hosting;

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
            private readonly IImageManipulatioнService imageManipulationService;
            private readonly IHostingEnvironment hostingEnvironment;

            public CreateArticleCommandHandler(
                ICurrentUser currentUser,
                IEditorRepository editorRepository,
                IArticleRepository articleRepository,
                IArticleFactory articleFactory,
                ISourceRepository sourceRepository,
                ICategoryRepository categoryRepository,
                IImageManipulatioнService imageManipulationService,
                IHostingEnvironment hostingEnvironment)
            {
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
                this.articleRepository = articleRepository;
                this.articleFactory = articleFactory;
                this.sourceRepository = sourceRepository;
                this.categoryRepository = categoryRepository;
                this.imageManipulationService = imageManipulationService;
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
                var imageUrl = request.ImageUrl;
                var imageName = Guid.NewGuid() + ".jpg";

                if (request.Image != null)
                {
                    imageUrl = @$"/Images/{imageName}";
                    var imageLocation = this.hostingEnvironment.ContentRootPath.Replace("Startup", "Web") + "/wwwroot/Images";
                    using (var fileStream = new FileStream(Path.Combine(imageLocation, imageName), FileMode.Create))
                    {
                        request.Image.CopyTo(fileStream);
                    }
                    byte[] myBinaryImage = File.ReadAllBytes(Path.Combine(imageLocation, imageName));
                    var resizedImage = imageManipulationService.ResizeImageStaticProportions(myBinaryImage, 460);
                    File.WriteAllBytes(Path.Combine(imageLocation, imageName), resizedImage);
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
