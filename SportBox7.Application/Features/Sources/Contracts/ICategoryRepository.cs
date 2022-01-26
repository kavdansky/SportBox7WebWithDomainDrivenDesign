namespace SportBox7.Application.Features.Sources.Contracts
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Queries.Common;
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
    }
}
