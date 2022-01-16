namespace SportBox7.Application.Features.Identity.Queries.AllUsers
{
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Features.Editors.Contracts;
    using SportBox7.Application.Features.Editors.Queries.Common;
    using System.Collections.Generic;

    public class ListUsersOutputModel: IEditorPage, IMetaTagable
    {
        public ListUsersOutputModel()
        {
            this.Users = new List<SimpleUserListingModel>();
        }

        public string MetaDescription => "Всички портебители - Sportbox7.com";

        public string MetaKeywords => "Всички портебители - Sportbox7.com";

        public string MetaTitle => "Всички портебители - Sportbox7.com";

        public IEnumerable<SimpleUserListingModel> Users { get; set; }
        public IEnumerable<EditorMenuElement> MenuElements { get; set; } = default!;
    }
}
