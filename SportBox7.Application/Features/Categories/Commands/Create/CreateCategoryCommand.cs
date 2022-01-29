namespace SportBox7.Application.Features.Categories.Commands.Create
{
    using AutoMapper;
    using MediatR;
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Categories.Commands.Common;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Application.Features.Editors;
    using SportBox7.Domain.Factories.Categories;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCategoryCommand: CategoryCommandBaseModel, IRequest<CreatedCategoryOutputModel>
    {
        public List<string> Errors { get; set; } = default!;

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryOutputModel>
        {
            private readonly ICategoryFactory categoryFactory;
            private readonly IEditorRepository editorRepository;
            private readonly ICurrentUser currentUser;
            private readonly ICategoryRepository categoryRepository;
            private readonly IMapper mapper;

            public CreateCategoryCommandHandler(ICategoryFactory categoryFactory, IEditorRepository editorRepository, ICurrentUser currentUser, ICategoryRepository categoryRepository, IMapper mapper)
            {
                this.categoryFactory = categoryFactory;
                this.editorRepository = editorRepository;
                this.currentUser = currentUser;
                this.categoryRepository = categoryRepository;
                this.mapper = mapper;
            }

            public async Task<CreatedCategoryOutputModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var categoryModel = this.categoryFactory
                    .WithCategoryName(request.CategoryName)
                    .WithCategoryNameEN(request.CategoryNameEN)
                    .Build();
                await this.categoryRepository.Save(categoryModel, cancellationToken);

                return new CreatedCategoryOutputModel() { Id = this.categoryRepository.GetCategoryByName(request.CategoryNameEN).Id };
            }
        }
    }
}
