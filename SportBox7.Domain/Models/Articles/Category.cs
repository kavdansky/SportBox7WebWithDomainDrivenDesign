namespace SportBox7.Domain.Models.Articles
{
    using SportBox7.Domain.Common;
    using SportBox7.Domain.Exeptions;

    public class Category: Entity<int>
    {
        private const byte DescriptionStringMinLength = 3;
        private const byte DescriptionStringMaxLength = 15;

        internal Category(string categoryName, string categoryNameEN)
        {
            this.Validate(categoryName, categoryNameEN);
            this.CategoryName = categoryName;
            this.CategoryNameEN = categoryNameEN;
        }

        public string CategoryName { get; private set; } = default!;

        public string CategoryNameEN { get; private set; } = default!;


        private void Validate(string categoryName, string categoryNameEN)
        {
            this.ValidateCategoryName(categoryName);
            this.ValidateCategoryNameEN(categoryNameEN);
        }

        private void ValidateCategoryNameEN(string categoryNameEN)
        {
            Validator.CheckForEmptyString<InvalidCategoryException>(categoryNameEN, "CategoryNameEN");
            Validator.CheckStringLength<InvalidCategoryException>(categoryNameEN, DescriptionStringMinLength, DescriptionStringMaxLength, "CategoryNameEN");
        }

        private void ValidateCategoryName(string categoryName)
        {
            Validator.CheckForEmptyString<InvalidCategoryException>(categoryName, "CategoryName");
            Validator.CheckStringLength<InvalidCategoryException>(categoryName, DescriptionStringMinLength, DescriptionStringMaxLength, "CategoryName");
        }
    }
}
