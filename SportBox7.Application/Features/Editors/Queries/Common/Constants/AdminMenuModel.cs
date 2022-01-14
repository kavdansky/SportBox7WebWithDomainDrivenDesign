namespace SportBox7.Application.Features.Editors.Queries.Common.Constants
{
    public class AdminMenuModel: EditorMenuModel
    {
        public AdminMenuModel()
        {
            this.MenuElements.Add(new EditorMenuElement("Users", "/identity/editors"));
        }
    }
}
