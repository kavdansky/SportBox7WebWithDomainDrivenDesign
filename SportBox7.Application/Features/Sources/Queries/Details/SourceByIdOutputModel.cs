﻿namespace SportBox7.Application.Features.Sources.Queries.Details
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Sources.Queries.Common;
    using SportBox7.Domain.Models.Sources;
    using System.Collections.Generic;

    public class SourceByIdOutputModel: SourceModel, IMetaTagable, IEditorPage
    {
        public int Id { get; set; }

        public string MetaDescription { get => $"Източник на информация- {this.SourceName}";}

        public string MetaKeywords { get => $"Източник на информация- {this.SourceName}";}

        public string MetaTitle { get => $"Източник на информация- {this.SourceName}";}

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Source, SourceByIdOutputModel>()
                .IncludeBase<Source, SourceModel>();
    }
}
