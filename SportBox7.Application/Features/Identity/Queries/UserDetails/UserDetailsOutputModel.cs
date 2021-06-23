namespace SportBox7.Application.Features.Identity.Queries.UserDetails
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using SportBox7.Application.Features.Articles.Contracts;
    using SportBox7.Application.Mapping;

    public class UserDetailsOutputModel: IMapFrom<IdentityUser>, IMetaTagable
    {
        public string Email { get; set; } = string.Empty;
       
        public string UserName { get; set; } = string.Empty;

        public string Id { get; set; } = default!;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MetaDescription => $"Детайли за {this.FirstName} {this.LastName}";

        public string MetaKeywords => $"Детайли за {this.FirstName} {this.LastName}";

        public string MetaTitle => $"Детайли за {this.FirstName} {this.LastName} - sportbox7";

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<IdentityUser, UserDetailsOutputModel>();
    }
}
