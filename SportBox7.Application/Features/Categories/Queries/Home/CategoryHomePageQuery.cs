namespace SportBox7.Application.Features.Categories.Queries.Home
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class CategoryHomePageQuery: IRequest<CategoryHomePageOutputModel>
    {
        public class CategoryHomePageQueryHandler : IRequestHandler<CategoryHomePageQuery, CategoryHomePageOutputModel>
        {
            private readonly ICategoryRepository categoryRepository;
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;

            public CategoryHomePageQueryHandler(ICategoryRepository categoryRepository, ICurrentUser currentUser, IEditorRepository editorRepository)
            {
                this.categoryRepository = categoryRepository;
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
            }

            public async Task<CategoryHomePageOutputModel> Handle(CategoryHomePageQuery request, CancellationToken cancellationToken)
            {
                return await CategoryHomePageOutputModel.CreateAsync(categoryRepository, editorRepository, currentUser);
            }
        }
    }
}
