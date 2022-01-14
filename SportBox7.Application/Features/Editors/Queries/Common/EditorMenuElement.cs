namespace SportBox7.Application.Features.Editors.Queries.Common
{
    public class EditorMenuElement
    {
        public EditorMenuElement(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }
        public string Name { get; set; } = default!;
        public string Url { get; set; } = default!;
    }
}
