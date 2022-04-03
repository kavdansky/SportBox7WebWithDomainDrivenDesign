namespace SportBox7.Application.Features.Articles.Queries.Common
{
    using AutoMapper;
    using SportBox7.Domain.Models.Articles;

    public abstract class BaseArticleModel
    {
        public BaseArticleModel()
        {}

        public BaseArticleModel(int id, string title, string categoryEN, string categoryName, string imageCredit, string imageUrl)
        {
            this.Id = id;
            this.Title = title;
            this.CategoryEN = categoryEN;
            this.CategoryName = categoryName;
            this.ImageCredit = imageCredit;
            this.ImageUrl = imageUrl;

        }
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string CategoryEN { get; set; } = default!;

        public string CategoryName { get; set; } = default!;

        public string ImageCredit { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public virtual void Mapping(Profile mapper)
        {
            mapper.CreateMap<Article, BaseArticleModel>()
                .IncludeAllDerived()
                .ForMember(art => art.CategoryEN, act => act.MapFrom(src => src.Category.CategoryNameEN))
                .ForMember(art => art.CategoryName, act => act.MapFrom(src => src.Source.SourceName));
        }
    }
}
