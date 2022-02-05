namespace SportBox7.Application.Features.Categories.Queries.Edit
{
    using AutoMapper;
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditCategoryQuery: IRequest<EditCategoryOutputModel>
    {
        public int Id { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public class EditCategoryQueryHandler : IRequestHandler<EditCategoryQuery, EditCategoryOutputModel>
        {
            private readonly ICategoryRepository categoryRepository;
            private readonly ICurrentUser currentUser;
            private readonly IMapper mapper;
            private readonly IEditorRepository editorRepository;

            public EditCategoryQueryHandler(ICategoryRepository categoryRepository, ICurrentUser currentUser, IMapper mapper, IEditorRepository editorRepository)
            {
                this.categoryRepository = categoryRepository;
                this.currentUser = currentUser;
                this.mapper = mapper;
                this.editorRepository = editorRepository;
            }

            public async Task<EditCategoryOutputModel> Handle(EditCategoryQuery request, CancellationToken cancellationToken)
            {
                var categoryToEdit = await this.categoryRepository.GetCategoryById(request.Id);
                var model = this.mapper.Map<EditCategoryOutputModel>(categoryToEdit);
                model.MenuElements = this.editorRepository.GetEditorMenuModel(currentUser.UserId);
                model.Errors = request.Errors;
                return model;
            }
        }
    }
}
