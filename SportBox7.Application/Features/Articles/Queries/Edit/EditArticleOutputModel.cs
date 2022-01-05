namespace SportBox7.Application.Features.Articles.Queries.Edit
{
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Domain.Models.Articles;

    public class EditArticleOutputModel: EditArticleModel
    {
        public EditArticleOutputModel()
        {}

        public int Id { get; set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, EditArticleOutputModel>()
                .IncludeBase<Article, EditArticleModel>();
    }
}
