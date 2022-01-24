namespace SportBox7.Application.Features.Sources.Queries.Common
{
    using AutoMapper;
    using SportBox7.Application.Mapping;
    using SportBox7.Domain.Models.Sources;
    using System.Collections.Generic;

    public class SourceModel: IMapFrom<Source>
    {
        public string ErrorMessage { get; set; } = default!;

        public List<string> Errors { get; set; }

        public SourceModel()
        {
            this.Errors = new List<string>();
        }

        public SourceModel(string sourceName, string sourceUrl, string sourceImageUrl)
        {
            this.SourceName = sourceName;
            this.SourceUrl = sourceUrl;
            this.SourceImageUrl = sourceImageUrl;
            this.Errors = new List<string>();
        }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Source, SourceModel>();
          
        public string SourceUrl { get; set; } = default!;

        public string SourceName { get; set; } = default!;

        public string SourceImageUrl { get; set; } = default!;
        
    }
}
