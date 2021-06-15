using System.Threading.Tasks;

namespace SportBox7.Application.Features.Identity.Queries.RegisterUser
{
    public class RegisterUserInputModel
    {
        private RegisterUserInputModel()
        { }
        public int Id { get; set; }

        public string ErrorMessage { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        private async Task<RegisterUserInputModel> InitializeAsync(string? errorMessage)
        {
            if (errorMessage != null)
            {
                this.ErrorMessage = errorMessage;
            }

            this.Email = await Task.Run(() => string.Empty);
            this.Password = await Task.Run(() => string.Empty);
            this.FirstName = await Task.Run(() => string.Empty);
            this.LastName = await Task.Run(() => string.Empty);
            return this;
        }

        public static async Task<RegisterUserInputModel> CreateAsync(string? errorMessage)
        {
            RegisterUserInputModel model = new RegisterUserInputModel();

            return await model.InitializeAsync(errorMessage);
        }
    }
}
