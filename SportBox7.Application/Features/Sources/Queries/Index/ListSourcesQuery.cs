using MediatR;
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

            public ListSourcesQueryHandler(ISourceRepository sourceRepository)
                => this.sourceRepository = sourceRepository;

            public async Task<SourcesOutputModel> Handle(ListSourcesQuery request, CancellationToken cancellationToken)
            {
                var model = await SourcesOutputModel.CreateAsync(sourceRepository);
                model.ErrorMessage = request.ErrorMessage;
                return model;
            }
        }
    }
}
