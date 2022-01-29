namespace SportBox7.Application.Features.Categories.Commands.Common
{
    using AutoMapper;
    using SportBox7.Domain.Models.Categories;

    public class CategoryCommandBaseModel
    {
        public CategoryCommandBaseModel() { }

        public string CategoryName { get; set; } = default!;

        public string CategoryNameEN { get; set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Category, CategoryCommandBaseModel>();
    }
}
