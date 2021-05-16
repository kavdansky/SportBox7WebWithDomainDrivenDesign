﻿namespace SportBox7.Application.Features.Sources.Commands.Edit
{
    public class EditedSourceOutputModel
    {
        public EditedSourceOutputModel(int sourceId, string sourceName)
        {
            this.SourceId = sourceId;
            this.SourceName = sourceName;
        }

        public int SourceId { get; set; }

        public string SourceName { get; set; } = default!;
    }
}
