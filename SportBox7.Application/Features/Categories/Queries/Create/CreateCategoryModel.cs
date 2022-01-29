namespace SportBox7.Application.Features.Categories.Queries.Create
{
    using AutoMapper;
    using SportBox7.Application.Features.Categories.Common;
    using SportBox7.Domain.Models.Categories;

    public class CreateCategoryModel: BaseCategoryModel
    {
        public override void Mapping(Profile mapper)
            => mapper
            .CreateMap<Category, CreateCategoryModel>()
            .IncludeBase<Category, BaseCategoryModel>();
    }
}
