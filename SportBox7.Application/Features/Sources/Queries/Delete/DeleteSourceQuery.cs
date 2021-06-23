namespace SportBox7.Application.Features.Sources.Queries.Delete
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteSourceQuery: IRequest<DeleteSourceOutputModel>
    {
        public int Id { get; set; }

        public string ErrorMessage { get; set; } = default!;

        public class EditSourceQueryHandler : IRequestHandler<DeleteSourceQuery, DeleteSourceOutputModel>
        {
            private readonly ISourceRepository sourceRepository;
         
            public EditSourceQueryHandler(ISourceRepository sourceRepository)
            {
                this.sourceRepository = sourceRepository;
            }

            public async Task<DeleteSourceOutputModel> Handle(DeleteSourceQuery request, CancellationToken cancellationToken)
            {
                var model = await this.sourceRepository.GetSourceToDeleteById(request.Id);
                //model.ErrorMessage = request.ErrorMessage;
                return model;
            }
        }
    }
}
