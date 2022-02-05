namespace SportBox7.Application.Features.Categories.Queries.Edit
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Categories.Common;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Domain.Models.Categories;
    using System.Collections.Generic;

    public class EditCategoryOutputModel: BaseCategoryModel, IEditorPage, IMetaTagable
    {
        public List<string> Errors { get; set; } = default!;

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public string MetaDescription => "Edit Category";

        public string MetaKeywords => "Edit Category";

        public string MetaTitle => "Edit Category";

        public int Id { get; set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Category, EditCategoryOutputModel>()
                .IncludeBase<Category, BaseCategoryModel>();

    }
}
