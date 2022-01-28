namespace SportBox7.Application.Features.Categories.Queries.Home
{
    using AutoMapper;
    using SportBox7.Application.Features.Categories.Common;
    using SportBox7.Domain.Models.Categories;

    public class CategoryListingModel: BaseCategoryModel
    {
        public int Id { get; set; }

        public CategoryListingModel()
        {}
        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Category, CategoryListingModel>()
                .IncludeBase<Category, BaseCategoryModel>();
    }
}
