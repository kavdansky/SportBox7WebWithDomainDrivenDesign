namespace SportBox7.Application.Features.Sources.Queries.Index
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Sources.Queries.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class SourcesOutputModel: IMetaTagable
    {

        public IEnumerable<IndexSourceModel> Sources { get; set; } = default!;

        public string ErrorMessage { get; set; } = default!;

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string MetaTitle { get; set; } = default!;

        private async Task<SourcesOutputModel> InitializeAsync(ISourceRepository sourceRepository)
        { 
            this.Sources = new List<IndexSourceModel>().AsReadOnly();
            this.MetaDescription = $"Източници на sportbox7.com";
            this.MetaKeywords = $"Източници на sportbox7.com";
            this.MetaTitle = $"Източници на sportbox7.com";
            this.Sources = await sourceRepository.GetAllSources();
            return this;
        }

        public static Task<SourcesOutputModel> CreateAsync(ISourceRepository sourceRepository)
        {
            var mapgeModel = new SourcesOutputModel();
            return mapgeModel.InitializeAsync(sourceRepository);
        }

    }
}
