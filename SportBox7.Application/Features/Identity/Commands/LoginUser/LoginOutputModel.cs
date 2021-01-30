namespace SportBox7.Application.Features.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string email, int editorId, string userId)
        {
            this.Email = email;
            this.EditorId = editorId;
            this.UserId = userId;
        }
        public string UserId { get; set; }

        public int EditorId { get; }

        public string Email { get; }
    }
}