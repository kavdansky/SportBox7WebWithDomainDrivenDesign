namespace SportBox7.Application.Features.Categories.Common
{
    using AutoMapper;
    using SportBox7.Application.Mapping;
    using SportBox7.Domain.Models.Categories;

    public class BaseCategoryModel: IMapFrom<Category>
    {
        public BaseCategoryModel(){}

        public string CategoryName { get; private set; } = default!;

        public string CategoryNameEN { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Category, BaseCategoryModel>();
    }
}
