namespace SportBox7.Application.Features.Sources.Commands.Edit
{
    using MediatR;
    using SportBox7.Application.Common;
    using SportBox7.Domain.Factories.Sources;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditSourceCommand: EditSourceInputModel, IRequest<Result<EditedSourceOutputModel>>
    {
        public class EditSourceCommandHandler : IRequestHandler<EditSourceCommand, Result<EditedSourceOutputModel>>
        {
            private readonly ISourceRepository sourceRepository;

            public EditSourceCommandHandler(ISourceRepository sourceRepository)
            {
                this.sourceRepository = sourceRepository;
            }

            public async Task<Result<EditedSourceOutputModel>> Handle(EditSourceCommand request, CancellationToken cancellationToken)
            {
                return await sourceRepository.EditSource(request);
            }
        }
    }
}
