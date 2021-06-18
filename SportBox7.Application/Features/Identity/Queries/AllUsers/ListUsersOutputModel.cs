namespace SportBox7.Application.Features.Identity.Queries.AllUsers
{
    using SportBox7.Application.Features.Articles.Contracts;
    using System.Collections.Generic;

    public class ListUsersOutputModel: IMetaTagable
    {
        public ListUsersOutputModel()
        {
            this.Users = new List<SimpleUserListingModel>();
        }

        public string MetaDescription => "Всички портебители - Sportbox7.com";

        public string MetaKeywords => "Всички портебители - Sportbox7.com";

        public string MetaTitle => "Всички портебители - Sportbox7.com";

        public IEnumerable<SimpleUserListingModel> Users { get; set; }

    }
}
