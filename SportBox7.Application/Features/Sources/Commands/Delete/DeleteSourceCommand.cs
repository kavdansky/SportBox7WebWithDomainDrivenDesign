namespace SportBox7.Application.Features.Sources.Commands.Delete
{
    using MediatR;
    using SportBox7.Application.Common;
    using SportBox7.Application.Features.Sources.Queries.Delete;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteSourceCommand
    {
        //public class DeleteSourceCommandHandler : IRequestHandler<DeleteSourceCommand, /Result<DeleteSourceInputModel>>
        //{
        //    private readonly ISourceRepository sourceRepository;
        //    public int Id { get; set; }
        //
        //
        //    public EditSourceCommandHandler(ISourceRepository sourceRepository)
        //    {
        //        this.sourceRepository = sourceRepository;
        //    }
        //
        //    public async Task<Result<DeletedSourceOutputModel>> Handle(DeleteSourceCommand request, /CancellationToken /cancellationToken)
        //    {
        //        return await sourceRepository.DeleteSource(request);
        //    }
        //}
    }
}
