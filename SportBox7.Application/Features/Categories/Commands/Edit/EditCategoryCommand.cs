namespace SportBox7.Application.Features.Categories.Commands.Edit
{
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Categories.Commands.Common;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Application.Features.Editors;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditCategoryCommand : CategoryCommandBaseModel, IRequest<EditedCategoryOutputModel>
    {
        public int Id { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, EditedCategoryOutputModel>
        {
            private readonly ICategoryRepository categoryRepository;

            public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                this.categoryRepository = categoryRepository;
            }

            public async Task<EditedCategoryOutputModel> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
            {
                return await this.categoryRepository.UpdateCategory(request);
            }
        }
    }
}
