namespace SportBox7.Application.Features.Sources.Queries.Create
{
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Sources.Queries.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreateSourceInputModel: SourceModel, IEditorPage
    {
        public CreateSourceInputModel()
        {

        }
        public CreateSourceInputModel(string sourceName, string sourceUrl, string sourceImageUrl)
        {
            this.SourceName = sourceName;
            this.SourceUrl = sourceUrl;
            this.SourceImageUrl = sourceImageUrl;
        }
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        private async Task<CreateSourceInputModel> InitializeAsync(List<string> errors)
        {
            if (errors.Count > 0)
            {
                this.Errors = errors;
            }

            this.SourceName = await Task.Run(() => string.Empty);
            this.SourceUrl = await Task.Run(() => string.Empty);
            this.SourceImageUrl = await Task.Run(() => string.Empty);

            return this;
        }

        public static async Task<CreateSourceInputModel> CreateAsync(List<string> errors)
        {
            CreateSourceInputModel model = new CreateSourceInputModel();

            return await model.InitializeAsync(errors);
        }
    }
}
