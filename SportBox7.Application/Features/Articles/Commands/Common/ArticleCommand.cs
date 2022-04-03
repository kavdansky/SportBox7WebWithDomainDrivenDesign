namespace SportBox7.Application.Features.Articles.Commands.Common
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;

    public abstract class ArticleCommand : EntityCommand<int>
    {
        public List<string> Errors { get; set; } = new List<string>();

        public string Title { get; set; } = default!;

        public string Body { get; set; } = default!;

        public string Category { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public IFormFile Image { get; set; } = default!;

        public string H1Tag { get; set; } = default!;

        public string ImageCredit { get; set; } = default!;

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public int ArticleType { get; set; }

        public string TargetDate { get; set; } = default!;

        public string Source { get; set; } = default!;


    }
}
