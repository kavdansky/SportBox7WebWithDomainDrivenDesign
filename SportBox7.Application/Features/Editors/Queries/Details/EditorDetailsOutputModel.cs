namespace SportBox7.Application.Features.Dealers.Queries.Details
{
    using AutoMapper;
    using Common;
    using Domain.Models.Editors;

    public class EditorDetailsOutputModel : EditorOutputModel
    {
        public int TotalArticles { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Editor, EditorDetailsOutputModel>()
                .IncludeBase<Editor, EditorOutputModel>()
                .ForMember(d => d.TotalArticles, cfg => cfg
                    .MapFrom(d => d.Articles.Count));
    }
}
