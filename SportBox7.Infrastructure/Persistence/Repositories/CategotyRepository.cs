namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using SportBox7.Application.Contracts;
    using SportBox7.Domain.Models.Categories;

    internal class CategoryRepository : DataRepository<Category>, IRepository<Category>
    {
        public CategoryRepository(SportBox7DbContext db)
            : base(db)
        {
        }
    }
}
