namespace SportBox7.Application.Features.Identity.Common
{
    using AutoMapper;
    using SportBox7.Application.Mapping;
    using SportBox7.Domain.Models.Editors;

    public class UserInputModel: IMapFrom<Editor>
    {
        public UserInputModel()
        {

        }
        public int Id { get; set; }

        public string ErrorMessage { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Editor, UserInputModel>();
    }
}
