namespace SportBox7.Application.Features.Identity.Commands.LoginUser
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using System.Collections.Generic;

    public class LoginOutputModel: IEditorPage, IMetaTagable
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
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;

        public string MetaDescription => "Welcome to your Dashboard";

        public string MetaKeywords => "Welcome to your Dashboard";

        public string MetaTitle => "Welcome to your Dashboard";
    }
}