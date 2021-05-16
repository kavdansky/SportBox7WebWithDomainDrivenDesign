namespace SportBox7.Application.Features.Sources.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class SourceByIdQuery : IRequest<SourceByIdOutputModel>
    {
        public int Id { get; set; }

        public class SourceByIdQueryHandler : IRequestHandler<SourceByIdQuery, SourceByIdOutputModel>
        {
            private readonly ISourceRepository sourceRepository;

            public SourceByIdQueryHandler(ISourceRepository sourceRepository)
            {
                this.sourceRepository = sourceRepository;
            }

            public Task<SourceByIdOutputModel> Handle(SourceByIdQuery request, CancellationToken cancellationToken)
            {
                return this.sourceRepository.GetSourceById(request.Id);
            }
        }
    }
}
