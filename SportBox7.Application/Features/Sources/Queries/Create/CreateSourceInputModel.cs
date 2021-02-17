using SportBox7.Application.Features.Sources.Queries.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Sources.Queries.Create
{
    public class CreateSourceInputModel: SourceModel
    {
        public string ErrorMessage { get; set; } = default!;

        private async Task<CreateSourceInputModel> InitializeAsync(string? errorMessage)
        {
            if (errorMessage != null)
            {
                this.ErrorMessage = errorMessage;
            }

            this.SourceName = await Task.Run(() => string.Empty);
            this.SourceUrl = await Task.Run(() => string.Empty);
            this.SourceImageUrl = await Task.Run(() => string.Empty);

            return this;
        }

        public static async Task<CreateSourceInputModel> CreateAsync(string? errorMessage)
        {
            CreateSourceInputModel model = new CreateSourceInputModel();

            return await model.InitializeAsync(errorMessage);
        }
    }
}
