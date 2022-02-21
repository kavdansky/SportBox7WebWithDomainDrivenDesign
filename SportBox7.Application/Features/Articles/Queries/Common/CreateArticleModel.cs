namespace SportBox7.Application.Features.Articles.Queries.Common
{ 
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using SportBox7.Application.Features.Articles.Commands.Common;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Sources;
    using System;
    using System.Collections.Generic;

    public class CreateArticleModel
    {
        public List<string> Errors { get; set; } = new List<string>();

        public string Title { get; set; } = default!;

        public string Body { get; set; } = default!;

        public string H1Tag { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public IFormFile Image { get; set; } = default!;

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public string SeoUrl { get; set; } = default!;
        
        public string Source { get; set; } = default!;

        public IEnumerable<MenuCategoriesModel> Categories { get; set; } = default!;

        public IEnumerable<Source> Sources { get; set; } = default!;

        public string Category { get; set; } = default!;

        public DateTime TargetDate { get; set; }

        public ArticleState ArticleState { get; set; }

        public ArticleType ArticleType { get; set; }

        public virtual void Mapping(Profile mapper)
        {
            mapper.CreateMap<ArticleCommand, CreateArticleModel>();
        } 
    }
}
