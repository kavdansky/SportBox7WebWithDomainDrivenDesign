namespace SportBox7.Application.Features.Sources.Queries.Edit
{
    using MediatR;
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

            public EditSourceQueryHandler(ISourceRepository sourceRepository)
            {
                this.sourceRepository = sourceRepository;
            }

            public async Task<EditSourceOutputModel> Handle(EditSourceQuery request, CancellationToken cancellationToken)
            {
                var model = await this.sourceRepository.GetSourceToEditById(request.Id);
                model.ErrorMessage = request.ErrorMessage;
                return model;
            }
        }
    }
}
