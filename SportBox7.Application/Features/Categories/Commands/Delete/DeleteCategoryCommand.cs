namespace SportBox7.Application.Features.Categories.Commands.Delete
{
    using MediatR;
    using SportBox7.Application.Features.Categories.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCategoryCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
        {
            private readonly ICategoryRepository categoryRepository;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                this.categoryRepository = categoryRepository;
            }
            public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                return await this.categoryRepository.DeleteCategory(request.Id);
            }
        }
    }
}
