namespace SportBox7.Application.Features.Identity.Commands.LoginUser
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(string userId, string email)
        {
            this.UserId = userId;
            this.Email = email;
        }

        public string UserId { get; }

        public string Email { get; set; }
    }
}
