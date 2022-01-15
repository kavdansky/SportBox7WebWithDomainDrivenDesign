namespace SportBox7.Application.Features.Articles.Queries.Edit
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Domain.Models.Articles;
    using System.Collections.Generic;

    public class EditArticleOutputModel: EditArticleModel, IEditorPage
    {
        public EditArticleOutputModel()
        {}

        public int Id { get; set; }
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, EditArticleOutputModel>()
                .IncludeBase<Article, EditArticleModel>();
    }
}
