namespace SportBox7.Application.Features.Sources.Commands.Create
{
    using SportBox7.Application.Features.Sources.Queries.Common;
    using System.Collections.Generic;

    public class CreateSourceOutputModel: SourceModel
    {
        

        public CreateSourceOutputModel()
        {
        }
        public CreateSourceOutputModel(int sourceId, string sourceName)
        {
            this.SourceId = sourceId;
            this.SourceName = sourceName;
        }

        public int SourceId { get; set; }

    }
}
