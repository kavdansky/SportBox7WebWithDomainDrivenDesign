namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Sources.Contracts;
    using SportBox7.Domain.Models.Categories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CategoryRepository : DataRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SportBox7DbContext db)
            : base(db)
        {
        }

        public async Task<Category> GetCategoryByName(string? name)
            => await this.All().Where(c => c.CategoryNameEN == name).FirstOrDefaultAsync();

        public async Task<Category> GetCurrentCategory(int articleId, CancellationToken cancellationToken = default)
            => await this.db
                .Categories
                .Where(c => c.CategoryNameEN == this.db.Articles.Include(a=> a.Category).Where(a=> a.Id == articleId).FirstOrDefault().Category.CategoryNameEN).FirstOrDefaultAsync();

        public async Task<List<MenuCategoriesModel>> GetMenuCategories()
            => await this.All().Select(x => new MenuCategoriesModel(x.CategoryName, x.CategoryNameEN)).ToListAsync();
    }
}
