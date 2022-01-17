namespace SportBox7.Application.Features.Sources.Queries.Delete
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Sources.Queries.Common;
    using SportBox7.Domain.Models.Sources;
    using System.Collections.Generic;

    public class DeleteSourceOutputModel : SourceModel, IMetaTagable, IEditorPage
    {
        public int Id { get; set; }

        public string MetaDescription { get { return $"Изтриване на източник на информация- {this.SourceName}"; } }

        public string MetaKeywords { get { return $"Изтриване на информация- {this.SourceName}"; } }

        public string MetaTitle { get { return $"Изтриване на информация- {this.SourceName}"; } }

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Source, DeleteSourceOutputModel>()
                .IncludeBase<Source, SourceModel>();
    }
}
