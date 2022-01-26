using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Categories;

namespace SportBox7.Domain.Factories.Categories
{
    internal class CategoryFactory : ICategoryFactory
    {
        private string categoryName = default!;
        private string categoryNameEN = default!;

        private bool isCategoryNameSet;
        private bool isCategoryNameENSet;

        public Category Build()
        {
            if (this.isCategoryNameENSet == false || this.isCategoryNameSet == false)
            {
                throw new InvalidCategoryException("Category name and CategoryNameEN must have value.");
            }
            return new Category(this.categoryName, this.categoryNameEN);
        }

        public ICategoryFactory WithCategoryName(string categoryName)
        {
            this.categoryName = categoryName;
            this.isCategoryNameSet = true;
            return this;
        }

        public ICategoryFactory WithCategoryNameEN(string categoryNameEN)
        {
            this.categoryNameEN = categoryNameEN;
            this.isCategoryNameENSet = true;
            return this;
        }
    }
}
