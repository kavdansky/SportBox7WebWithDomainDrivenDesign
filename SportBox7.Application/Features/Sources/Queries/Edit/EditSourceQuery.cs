namespace SportBox7.Application.Features.Sources.Queries.Edit
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditSourceQuery: IRequest<EditSourceOutputModel>
    {
        public int Id { get; set; }

        public class EditSourceQueryHandler : IRequestHandler<EditSourceQuery, EditSourceOutputModel>
        {
            private readonly ISourceRepository sourceRepository;

            public EditSourceQueryHandler(ISourceRepository sourceRepository)
            {
                this.sourceRepository = sourceRepository;
            }

            public Task<EditSourceOutputModel> Handle(EditSourceQuery request, CancellationToken cancellationToken)
            {
                return this.sourceRepository.GetSourceToEditById(request.Id);
            }
        }
    }
}
