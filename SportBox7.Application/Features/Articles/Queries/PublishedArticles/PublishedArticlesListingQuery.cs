namespace SportBox7.Application.Features.Articles.Queries.PublishedArticles
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class PublishedArticlesListingQuery: IRequest<PublishedArticlesListingOutputModel>
    {
        public class PublishedArticlesListingQueryHandler : IRequestHandler<PublishedArticlesListingQuery, PublishedArticlesListingOutputModel>
        {
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;

            public PublishedArticlesListingQueryHandler(IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }

            public async Task<PublishedArticlesListingOutputModel> Handle(PublishedArticlesListingQuery request, CancellationToken cancellationToken)
            {
                return await PublishedArticlesListingOutputModel.CreateAsync(editorRepository, currentUser.UserId);
            }
        }
    }
}
