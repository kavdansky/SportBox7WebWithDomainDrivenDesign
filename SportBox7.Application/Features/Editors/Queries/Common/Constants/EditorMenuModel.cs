namespace SportBox7.Application.Features.Editors.Queries.Common.Constants
{
    using System.Collections.Generic;

    public class EditorMenuModel
    {
        public EditorMenuModel()
        {
            this.MenuElements = new List<EditorMenuElement>
            {
                new EditorMenuElement("Dashboard", "/editors/index"),
                new EditorMenuElement("Drafts", "/editorsarticles/drafts"),
                new EditorMenuElement("Articles", "/editorsarticles/publishedarticles"),
                new EditorMenuElement("Sources", "/sources")
            };
        }
        public IList<EditorMenuElement> MenuElements { get; set; }
    }
}
