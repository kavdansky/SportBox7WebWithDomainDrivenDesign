namespace SportBox7.Application.Features.Sources.Queries.Edit
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditSourceQuery: IRequest<EditSourceOutputModel>
    {
        public int Id { get; set; }

        public string ErrorMessage { get; set; } = default!;

        public class EditSourceQueryHandler : IRequestHandler<EditSourceQuery, EditSourceOutputModel>
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

            public async Task<EditSourceOutputModel> Handle(EditSourceQuery request, CancellationToken cancellationToken)
            {
                var model = await this.sourceRepository.GetSourceToEditById(request.Id);
                model.ErrorMessage = request.ErrorMessage;
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
