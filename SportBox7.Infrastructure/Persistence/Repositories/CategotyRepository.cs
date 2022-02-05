namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Categories.Contracts;
    using SportBox7.Application.Features.Categories.Queries.Home;
    using SportBox7.Domain.Models.Categories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CategoryRepository : DataRepository<Category>, ICategoryRepository
    {
        private readonly IMapper mapper;

        public CategoryRepository(SportBox7DbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<List<CategoryListingModel>> GetCategoriesListingModel()
            => await this.mapper.ProjectTo<CategoryListingModel>(this.All()).ToListAsync();

        public async Task<Category> GetCategoryById(int id)
            => await this.All().Where(c => c.Id == id).FirstOrDefaultAsync();

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
