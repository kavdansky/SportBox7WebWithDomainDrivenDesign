namespace SportBox7.Application.Features.Identity.Queries.RegisterUser
{
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using SportBox7.Application.Features.Identity.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RegisterUserInputModel: UserInputModel, IEditorPage
    {
        public RegisterUserInputModel()
        { }
        public new List<string> ErrorMessage { get; set; } = default!;
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        private async Task<RegisterUserInputModel> InitializeAsync(List<string> errorMessage)
        {
            if (errorMessage != null)
            {
                this.ErrorMessage = errorMessage;
            }
            else
            {
                this.ErrorMessage = new List<string>();
            }

            this.Email = await Task.Run(() => string.Empty);
            this.Password = await Task.Run(() => string.Empty);
            this.FirstName = await Task.Run(() => string.Empty);
            this.LastName = await Task.Run(() => string.Empty);
            return this;
        }

        public static async Task<RegisterUserInputModel> CreateAsync(List<string> errorMessage)
        {
            RegisterUserInputModel model = new RegisterUserInputModel();

            return await model.InitializeAsync(errorMessage);
        }
    }
}
