using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportBox7.Application.Features.Identity.Queries.LoginUser
{
    public class LoginUserInputModel
    {
        private LoginUserInputModel()
        {}
        public string ErrorMessage { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        private async Task<LoginUserInputModel> InitializeAsync(string? errorMessage)
        {
            if (errorMessage != null)
            {
                this.ErrorMessage = errorMessage;
            }
            
            Email = await Task.Run(() => string.Empty);
            Password = await Task.Run(() => string.Empty);
            return this;
        }

        public static async Task<LoginUserInputModel> CreateAsync(string? errorMessage)
        {
            LoginUserInputModel model = new LoginUserInputModel();
            
            return await model.InitializeAsync(errorMessage);
        }
    }
}
