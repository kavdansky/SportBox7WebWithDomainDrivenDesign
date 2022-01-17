using MediatR;
using SportBox7.Application.Contracts;
using SportBox7.Application.Features.Editors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Sources.Queries.Index
{
    public class ListSourcesQuery: IRequest<SourcesOutputModel>
    {
        public string ErrorMessage { get; set; } = default!;

        public class ListSourcesQueryHandler : IRequestHandler<ListSourcesQuery, SourcesOutputModel>
        {
            private readonly ISourceRepository sourceRepository;
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public ListSourcesQueryHandler(ISourceRepository sourceRepository, ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.sourceRepository = sourceRepository;
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
            } 

            public async Task<SourcesOutputModel> Handle(ListSourcesQuery request, CancellationToken cancellationToken)
            {
                var model = await SourcesOutputModel.CreateAsync(sourceRepository);
                model.ErrorMessage = request.ErrorMessage;
                model.MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
