namespace SportBox7.Application.Features.Categories.Queries.Delete
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Categories.Common;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Domain.Models.Categories;
    using System.Collections.Generic;

    public class DeleteCategoryOutputModel: BaseCategoryModel, IEditorPage, IMetaTagable
    {
        public int Id { get; set; }

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public string MetaDescription => "Delete Category";

        public string MetaKeywords => "Delete Category";

        public string MetaTitle => "Delete Category";

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Category, DeleteCategoryOutputModel>()
                .IncludeBase<Category, BaseCategoryModel>();
    }
}
