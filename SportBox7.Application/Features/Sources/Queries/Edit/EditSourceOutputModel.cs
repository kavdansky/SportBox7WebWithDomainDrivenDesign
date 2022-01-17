namespace SportBox7.Application.Features.Sources.Queries.Edit
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Sources.Commands.Edit;
    using SportBox7.Application.Features.Sources.Queries.Common;
    using SportBox7.Domain.Models.Sources;


    public class EditSourceOutputModel : EditSourceInputModel, IMetaTagable
    {
        public string MetaDescription { get { return $"Редактиране на източник на информация- {this.SourceName}"; } }

        public string MetaKeywords { get { return $"Редактиране на информация- {this.SourceName}"; } }
        
        public string MetaTitle { get { return $"Редактиране на информация- {this.SourceName}"; } }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Source, EditSourceOutputModel>()
                .IncludeBase<Source, SourceModel>();
    }
}
