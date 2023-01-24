namespace SportBox7.Application.Features.Articles.Queries.Common
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using SportBox7.Application.Mapping;
    using SportBox7.Domain.Models.Articles;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Sources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditArticleModel: IMapFrom<Article>
    {
        public List<string> Errors { get; set; } = new List<string>();

        public string Title { get; private set; } = default!;

        public string Body { get; private set; } = default!;

        public string H1Tag { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public IFormFile Image { get; set; } = default!;

        public string MetaDescription { get; private set; } = default!;

        public string MetaKeywords { get; private set; } = default!;

        public string ImageCredit { get; private set; } = default!;

        public string Source { get; set; } = default!;

        public IEnumerable<MenuCategoriesModel> Categories { get; set; } = default!;

        public IEnumerable<Source> Sources { get; set; } = default!;

        public string Category { get; set; } = default!;

        [DataType(DataType.Date)]
        public DateTime TargetDate { get; private set; }

        public ArticleState ArticleState { get; set; }

        public ArticleType ArticleType { get; private set; }

        public virtual void Mapping(Profile mapper)
        {
            mapper.CreateMap<Article, EditArticleModel>()
                .ForMember(art => art.Category, act => act.MapFrom(src => src.Category.CategoryNameEN))
                .ForMember(art => art.Source, act => act.MapFrom(src => src.Source.SourceName));
        }
    }
}
