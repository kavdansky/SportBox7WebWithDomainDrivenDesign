namespace SportBox7.Application.Features.Sources.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Application.Features.Sources.Queries.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateSourceQuery: SourceModel, IRequest<CreateSourceInputModel>
    {
        public class CreateSourceQueryHandler : IRequestHandler<CreateSourceQuery, CreateSourceInputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public CreateSourceQueryHandler(ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }
            public async Task<CreateSourceInputModel> Handle(CreateSourceQuery request, CancellationToken cancellationToken)
            {
                var model = await CreateSourceInputModel.CreateAsync(request.Errors);
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
