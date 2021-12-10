namespace SportBox7.Application.Features.Identity.Commands.CreateUser
{
    public class CreateUserOutputModel
    {
        public CreateUserOutputModel()
        {
            this.Email = "";
        }

        public CreateUserOutputModel(string email)
        {
            this.Email = email;
        }
        public string Email { get; set; }
    }
}
