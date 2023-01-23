namespace SportBox7.Application.Features.Sources.Queries.Index
{
    using SportBox7.Application.Contracts;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SourcesOutputModel: IMetaTagable, IEditorPage
    {

        public IPaginatedList<IndexSourceModel> Sources { get; set; } = default!;

        public string ErrorMessage { get; set; } = default!;

        public string MetaDescription { get; set; } = $"Източници на sportbox7.com";

        public string MetaKeywords { get; set; } = $"Източници на sportbox7.com";

        public string MetaTitle { get; set; } = $"Източници на sportbox7.com";

        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        private async Task<SourcesOutputModel> InitializeAsync(ISourceRepository sourceRepository, int index)
        { 
            this.Sources = await sourceRepository.GetPaginatedSources(index);
            return this;
        }

        public static Task<SourcesOutputModel> CreateAsync(ISourceRepository sourceRepository, int index)
        {
            var mapgeModel = new SourcesOutputModel();
            return mapgeModel.InitializeAsync(sourceRepository, index);
        }

    }
}
