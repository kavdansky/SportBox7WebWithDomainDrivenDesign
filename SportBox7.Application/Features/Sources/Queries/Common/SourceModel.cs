using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Sources.Queries.Common
{
    public class SourceModel
    {
        public string SourceUrl { get; set; } = default!;

        public string SourceName { get; set; } = default!;

        public string SourceImageUrl { get; set; } = default!;
    }
}
