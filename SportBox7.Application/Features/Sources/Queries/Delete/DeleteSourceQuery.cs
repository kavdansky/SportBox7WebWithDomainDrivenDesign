namespace SportBox7.Application.Features.Sources.Queries.Delete
{
    using AutoMapper;
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteSourceQuery: IRequest<DeleteSourceOutputModel>
    {
        public int Id { get; set; }

        public string ErrorMessage { get; set; } = default!;

        public class EditSourceQueryHandler : IRequestHandler<DeleteSourceQuery, DeleteSourceOutputModel>
        {
            private readonly ISourceRepository sourceRepository;
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;
         
            public EditSourceQueryHandler(ISourceRepository sourceRepository, ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.sourceRepository = sourceRepository;
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
            }

            public async Task<DeleteSourceOutputModel> Handle(DeleteSourceQuery request, CancellationToken cancellationToken)
            {
                var model = await this.sourceRepository.GetSourceToDeleteById(request.Id);
                model.MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
