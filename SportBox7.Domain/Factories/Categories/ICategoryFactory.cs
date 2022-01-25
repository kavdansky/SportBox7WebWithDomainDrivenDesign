namespace SportBox7.Domain.Factories.Categories
{
    using SportBox7.Domain.Models.Categories;

    public interface ICategoryFactory: IFactory<Category>
    {
        ICategoryFactory WithCategoryName(string categoryName);

        ICategoryFactory WithCategoryNameEN(string categoryNameEN);
    }
}
