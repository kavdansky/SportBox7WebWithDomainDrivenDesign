namespace SportBox7.Application.Features.Editors.Queries.Common.Constants
{
    using System.Collections.Generic;

    public class EditorMenuModel
    {
        public EditorMenuModel()
        {
            this.MenuElements = new List<EditorMenuElement>();
            this.MenuElements.Add(new EditorMenuElement("Dashboard", "/editors/index"));
            this.MenuElements.Add(new EditorMenuElement("Drafts", "/editorsarticles/drafts"));
            this.MenuElements.Add(new EditorMenuElement("Articles", "/editorsarticles/publishedarticles"));
            this.MenuElements.Add(new EditorMenuElement("Sources", "/sources"));
        }
        public IList<EditorMenuElement> MenuElements { get; set; }
    }
}
