namespace SportBox7.Application.Features.Articles.Queries.PublishedArticles
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class PublishedArticlesListingQuery: IRequest<PublishedArticlesListingOutpuModel>
    {
        public class PublishedArticlesListingQueryHandler : IRequestHandler<PublishedArticlesListingQuery, PublishedArticlesListingOutpuModel>
        {
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;

            public PublishedArticlesListingQueryHandler(IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }

            public async Task<PublishedArticlesListingOutpuModel> Handle(PublishedArticlesListingQuery request, CancellationToken cancellationToken)
            {
                return await PublishedArticlesListingOutpuModel.CreateAsync(editorRepository, currentUser.UserId);
            }
        }
    }
}
