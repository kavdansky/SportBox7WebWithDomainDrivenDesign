namespace SportBox7.Application.Features.Categories.Contracts
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Categories.Commands.Edit;
    using SportBox7.Application.Features.Categories.Queries.Home;
    using SportBox7.Domain.Models.Categories;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICategoryRepository: IRepository<Category>
    {
        Task<List<MenuCategoriesModel>> GetMenuCategories();

        Task<Category> GetCategoryByName(string? name);

        Task<Category> GetCurrentCategory(
            int articleId,
            CancellationToken cancellationToken = default);

        Task<List<CategoryListingModel>> GetCategoriesListingModel();

        Task<Category> GetCategoryById(int id);

        Task<EditedCategoryOutputModel> UpdateCategory(EditCategoryCommand command);

        Task<bool> DeleteCategory(int id);
    }
}
