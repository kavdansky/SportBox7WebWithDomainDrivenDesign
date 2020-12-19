namespace SportBox7.Application.Features.Dealers.Queries.Common
{
    using AutoMapper;
    using Domain.Models.Editors;
    using Mapping;

    public class EditorOutputModel : IMapFrom<Editor>
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Editor, EditorOutputModel>()
                .ForMember(d => d.FirstName, cfg => cfg
                    .MapFrom(d => d.FirstName));
    }
}
