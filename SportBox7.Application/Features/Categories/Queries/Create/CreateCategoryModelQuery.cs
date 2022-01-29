namespace SportBox7.Application.Features.Categories.Queries.Create
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Categories.Common;
    using SportBox7.Application.Features.Editors;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCategoryModelQuery: BaseCategoryModel, IRequest<CreateCategoryOutputModel>
    {
        public List<string> Errors { get; set; } = default!;

        public class CreateCategoryModelQueryHandler : IRequestHandler<CreateCategoryModelQuery, CreateCategoryOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public CreateCategoryModelQueryHandler(IEditorRepository editorRepository, ICurrentUser currentUser)
            {
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
            }
            public async Task<CreateCategoryOutputModel> Handle(CreateCategoryModelQuery request, CancellationToken cancellationToken)
            {
                var model = await CreateCategoryOutputModel.CreateAsync(editorRepository, currentUser);
                model.CategoryName = request.CategoryName;
                model.CategoryNameEN = request.CategoryNameEN;
                model.Errors = request.Errors;
                return model;
            } 
        }
    }
}
