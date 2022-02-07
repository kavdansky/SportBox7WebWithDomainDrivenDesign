namespace SportBox7.Application.Features.Categories.Queries.Delete
{
    using AutoMapper;
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCategoryQuery: IRequest<DeleteCategoryOutputModel>
    {
        public int Id { get; set; }

        public class DeleteCategoryQueryHandler : IRequestHandler<DeleteCategoryQuery, DeleteCategoryOutputModel>
        {
            private readonly ICategoryRepository categoryRepository;
            private readonly ICurrentUser currentUser;
            private readonly IEditorRepository editorRepository;
            private readonly IMapper mapper;

            public DeleteCategoryQueryHandler(ICategoryRepository categoryRepository, ICurrentUser currentUser, IEditorRepository editorRepository, IMapper mapper)
            {
                this.categoryRepository = categoryRepository;
                this.currentUser = currentUser;
                this.editorRepository = editorRepository;
                this.mapper = mapper;
            }

            public async Task<DeleteCategoryOutputModel> Handle(DeleteCategoryQuery request, CancellationToken cancellationToken)
            {
                var model = mapper.Map<DeleteCategoryOutputModel>(await this.categoryRepository.GetCategoryById(request.Id));
                model.MenuElements = editorRepository.GetEditorMenuModel(currentUser.UserId);
                return model;
            }
        }
    }
}
