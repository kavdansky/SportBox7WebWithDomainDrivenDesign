namespace SportBox7.Application.Features.Articles.Queries.Common
{
    public class MenuCategoriesModel
    {
        public MenuCategoriesModel(string name, string nameEn)
        {
            this.Name = name;
            this.NameEn = nameEn;
        }

        public string Name { get; set; }

        public string NameEn { get; set; }

    }
}
