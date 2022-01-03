namespace SportBox7.Application.Features.Articles.Queries.Common
{ 
    using AutoMapper;
    using SportBox7.Application.Features.Articles.Commands.Common;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Sources;
    using System;
    using System.Collections.Generic;

    public class CreateDraftArticleModel
    {
        public List<string> Errors { get; set; } = new List<string>();

        public string Title { get; private set; } = default!;

        public string Body { get; private set; } = default!;

        public string H1Tag { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public string MetaDescription { get; private set; } = default!;

        public string MetaKeywords { get; private set; } = default!;

        public string SeoUrl { get; private set; } = default!;
        
        public string Source { get; set; } = default!;

        public IEnumerable<MenuCategoriesModel> Categories { get; set; } = default!;

        public IEnumerable<Source> Sources { get; set; } = default!;

        public string Category { get; set; } = default!;

        public DateTime TargetDate { get; private set; }

        public ArticleState ArticleState { get; private set; }

        public ArticleType ArticleType { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<ArticleCommand, CreateDraftArticleModel>();
    }
}
