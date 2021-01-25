namespace SportBox7.Application.Features.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int editorId)
        {
            this.Token = token;
            this.EditorId = editorId;
        }

        public int EditorId { get; }

        public string Token { get; }
    }
}