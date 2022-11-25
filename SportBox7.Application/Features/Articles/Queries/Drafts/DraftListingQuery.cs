namespace SportBox7.Application.Features.Articles.Queries.Drafts
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class DraftListingQuery: IRequest<DraftsListingOutputModel>
    {
        public int PageIndex { get; set; }

        public class DraftListingQueryHandler : IRequestHandler<DraftListingQuery, DraftsListingOutputModel>
        {
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;

            public DraftListingQueryHandler(IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }

            public async Task<DraftsListingOutputModel> Handle(DraftListingQuery request, CancellationToken cancellationToken)
            {
                return await DraftsListingOutputModel.CreateAsync(editorRepository, currentUser.UserId, request.PageIndex);
            }
        }
    }
}
