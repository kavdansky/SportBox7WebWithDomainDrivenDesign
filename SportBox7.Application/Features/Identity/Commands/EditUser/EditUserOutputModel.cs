namespace SportBox7.Application.Features.Identity.Commands.EditUser
{
    public class EditUserOutputModel
    {
        public EditUserOutputModel(string email)
        {
            this.Email = email;
        }
        public string Email { get; set; }
    }
}
