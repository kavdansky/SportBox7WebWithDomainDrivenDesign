using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Sources.Commands.Create
{
    public class CreateSourceOutputModel
    {
        public CreateSourceOutputModel(int sourceId, string sourceName)
        {
            this.SourceId = sourceId;
            this.SourceName = sourceName;
        }

        public int SourceId { get; set; }

        public string SourceName { get; set; } = default!;
    }
}
