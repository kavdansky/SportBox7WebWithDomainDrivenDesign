namespace SportBox7.Application.Features.Sources.Commands.Create
{
    using MediatR;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Sources.Queries.Create;
    using SportBox7.Domain.Factories.Sources;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateSourceCommand: CreateSourceInputModel, IRequest<Result<CreateSourceOutputModel>>
    {
        
        public class CreateSourceCommandHandler : IRequestHandler<CreateSourceCommand, Result<CreateSourceOutputModel>>
        {
            private readonly ISourceFactory sourceFactory;
            private readonly ISourceRepository sourceRepository;

            public CreateSourceCommandHandler(ISourceFactory sourceFactory, ISourceRepository sourceRepository)
            {
                this.sourceFactory = sourceFactory;
                this.sourceRepository = sourceRepository;
            }

            public async Task<Result<CreateSourceOutputModel>> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
            {
                var source = this.sourceFactory
                    .WithSourceName(request.SourceName)
                    .WithSourceUrl(request.SourceUrl)
                    .WithSourceImageUrl(request.SourceImageUrl)
                    .Build();

                await this.sourceRepository.Save(source, cancellationToken);

                return await Task.Run(() => new CreateSourceOutputModel(source.Id, source.SourceName)); 
            }
        }

    }
}
