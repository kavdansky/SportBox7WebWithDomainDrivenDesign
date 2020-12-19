namespace SportBox7.Application.Features.Articles.Queries.Category
{
    public class ArticleListingModel
    {
        public ArticleListingModel(
            int id, 
            string title,
            string body,
            string imageUrl,
            string category,
            string seoUrl)
        {
            this.Id = id;
            this.Title = title;
            this.Body = body;
            this.ImageUrl = imageUrl;
            this.Category = category;
            this.SeoUrl = seoUrl;
        }

        public int Id { get; }

        public string Title { get; }

        public string Body { get; }

        public string ImageUrl { get; }

        public string Category { get; }

        public string SeoUrl { get; set; }


    }
}
