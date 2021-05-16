using SportBox7.Application.Features.Sources.Queries.Common;

namespace SportBox7.Application.Features.Sources.Queries.Index
{
    public class IndexSourceModel: SourceModel
    {
        public IndexSourceModel()
        {}

        public IndexSourceModel(int id, string sourceName, string sourceUrl, string sourceImageUrl)
            :base(sourceName, sourceUrl, sourceImageUrl)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
