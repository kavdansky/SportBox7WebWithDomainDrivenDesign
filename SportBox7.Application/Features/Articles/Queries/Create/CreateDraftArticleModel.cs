namespace SportBox7.Application.Features.Articles.Queries.Create
{
    using SportBox7.Application.Features.Articles.Queries.Common;
    using SportBox7.Domain.Models.Articles.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateDraftArticleModel
    {
        public string Title { get; private set; } = default!;

        public string Body { get; private set; } = default!;

        public string H1Tag { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public string MetaDescription { get; private set; } = default!;

        public string MetaKeywords { get; private set; } = default!;

        public string SeoUrl { get; private set; } = default!;

        public IEnumerable<string> Source { get; set; } = default!;

        public IEnumerable<MenuCategoriesModel> Categories { get; set; } = default!;

        public DateTime? TargetDate { get; private set; }

        public ArticleState ArticleState { get; private set; }

        public ArticleType ArticleType { get; private set; }
    }
}
