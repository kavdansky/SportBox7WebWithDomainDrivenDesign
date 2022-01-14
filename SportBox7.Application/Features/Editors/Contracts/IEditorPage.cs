namespace SportBox7.Application.Features.Editors.Contracts
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using System.Collections.Generic;

    interface IEditorPage
    {
        IEnumerable<EditorMenuElement> MenuElements { get; set; }
    }
}
