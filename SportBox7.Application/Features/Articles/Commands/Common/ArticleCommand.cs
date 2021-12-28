namespace SportBox7.Application.Features.Articles.Commands.Common
{
    public abstract class ArticleCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {

        public string Title { get; set; } = default!;

        public string Body { get; set; } = default!;

        public string Category { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public string H1Tag { get; set; } = default!;

        public string SeoUrl { get; set; } = default!;

        public string MetaDescription { get; set; } = default!;

        public string MetaKeywords { get; set; } = default!;

        public int ArticleType { get; set; }

        public string TargetDate { get; set; } = default!;

        public string Source { get; set; } = default!;
    }
}
