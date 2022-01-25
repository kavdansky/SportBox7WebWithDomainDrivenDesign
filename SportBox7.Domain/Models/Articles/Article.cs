namespace SportBox7.Domain.Models.Articles
{
    using SportBox7.Domain.Common;
    using System;
    using SportBox7.Domain.Exeptions;
    using System.Collections.Generic;
    using SportBox7.Domain.Models.Articles.Enums;
    using System.Linq;
    using static SportBox7.Domain.Models.ModelConstants.Common;
    using static SportBox7.Domain.Models.ModelConstants.Article;
    using SportBox7.Domain.Models.Categories;

    public class Article: EditableEntity<int>, IAggregateRoot
    {
        private readonly HashSet<SocialSignal> socialSignals;

        internal Article(string title, string body, string h1Tag, string imageUrl, string seoUrl, string metaDescription, string metaKeywords, Category category, ArticleType articleType, DateTime targetDate, Models.Sources.Source source)
        {
            this.Validate(title, body, h1Tag, imageUrl, metaKeywords, metaDescription);
           
            this.TargetDate = targetDate;
            this.ArticleType = articleType;           
            this.CreationDate = DateTime.Now;
            this.LastModDate = this.CreationDate;
            this.Title = title;
            this.Body = body;
            this.H1Tag = h1Tag;
            this.ImageUrl = imageUrl;
            this.SeoUrl = seoUrl;
            this.MetaKeywords = metaKeywords;
            this.MetaDescription = metaDescription;
            this.Category = category;
            this.ArticleState = ArticleState.Draft;
            this.ArticleType = ArticleType;
            this.socialSignals = new HashSet<SocialSignal>();
            this.Source = source;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private Article(string title, string body, string h1Tag, string imageUrl, string seoUrl, string metaDescription, string metaKeywords)
#pragma warning restore IDE0051 // Remove unused private members
        {
            this.Validate(title, body, h1Tag, imageUrl, metaKeywords, metaDescription);

            this.CreationDate = DateTime.Now;
            this.LastModDate = this.CreationDate;
            this.Title = title;
            this.Body = body;
            this.H1Tag = h1Tag;
            this.ImageUrl = imageUrl;
            this.SeoUrl = seoUrl;
            this.MetaKeywords = metaKeywords;
            this.MetaDescription = metaDescription;
            this.ArticleType = ArticleType;         
            this.ArticleState = default!;
            this.ArticleType = default!;
            this.TargetDate = default!;
            this.Category = default!;
            this.socialSignals = new HashSet<SocialSignal>();
            this.Source = default!;

        }

        private void Validate(string title, string body, string h1Tag, string imageUrl, string metaKeywords, string metaDescription)
        {
            this.ValidateTitle(title);
            this.ValidateBody(body);
            this.ValidateH1Tag(h1Tag);
            this.ValidateImageUrl(imageUrl);
            this.ValidateMetaKeywords(metaKeywords);
            this.ValidateMetaDescription(metaDescription);
            
        }

        public string Title { get; private set; } = default!;

        public string Body { get; private set; } = default!;

        public string H1Tag { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public string MetaDescription { get; private set; } = default!;

        public string MetaKeywords { get; private set; } = default!;

        public string SeoUrl { get; private set; } = default!;

        public Models.Sources.Source Source { get; private set; }

        public Category Category { get; private set; }
       
        public DateTime TargetDate { get; private set; } 

        public ArticleState ArticleState { get; private set; }

        public ArticleType ArticleType { get; private set; }

        public IReadOnlyCollection<SocialSignal> SocialSignals => this.socialSignals.ToList().AsReadOnly();



        public Article UpdateArticleState(ArticleState articleState)
        {
            this.ArticleState = articleState;

            return this;
        }

        public Article UpdateArticleType(ArticleType articleType)
        {
            this.ArticleType = articleType;

            return this;
        }

        public Article UpdateBody(string body)
        {
            this.ValidateBody(body);
            this.Body = body;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateCategory(Category category)
        {
            this.Category = category;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateH1Tag(string h1Tag)
        {
            this.ValidateH1Tag(h1Tag);
            this.H1Tag = h1Tag;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateMetaDescription(string metaDescription)
        {
            this.ValidateMetaDescription(metaDescription);
            this.MetaDescription = metaDescription;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateMetaKeywords(string metaKeywords)
        {
            this.ValidateMetaKeywords(metaKeywords);
            this.MetaKeywords = metaKeywords;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateSource(Models.Sources.Source source)
        {
            this.Source = source;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateSeoUrl(string seoUrl)
        {
            this.ValidateSeoUrl(seoUrl);
            this.SeoUrl = seoUrl;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateTargetDate(DateTime targetDate)
        {
            if (this.ArticleType == ArticleType.NewsArticle)
            {
                throw new InvalidArticleException("News Articles cannot have a Target Date");
            }
            this.TargetDate = targetDate;
            this.LastModDate = DateTime.Now;

            return this;
        }

        public Article UpdateTitle(string title)
        {

            this.ValidateTitle(title);
            this.Title = title;
            this.LastModDate = DateTime.Now;

            return this;
        }

        private void ValidateSeoUrl(string seoUrl)
        {
            Validator.CheckValidUrl<InvalidArticleException>(seoUrl, "SeoUrl");
        }

        private void ValidateMetaKeywords(string metaKeywords)
        {
            Validator.CheckForEmptyString<InvalidArticleException>(metaKeywords, "MetaDescription");
            Validator.CheckStringLength<InvalidArticleException>(metaKeywords, MetatagsMinLength, MetatagsMaxLength, "MetaDescription");
        }

        private void ValidateImageUrl(string imageUrl)
        {
            Validator.CheckValidUrl<InvalidArticleException>(imageUrl, "ImageUrl");
            
        }

        private void ValidateH1Tag(string h1Tag)
        {
            Validator.CheckForEmptyString<InvalidArticleException>(h1Tag, "H1Tag");
            Validator.CheckStringLength<InvalidArticleException>(h1Tag, H1MinLength, H1MaxLength, "H1Tag");
        }

        private void ValidateBody(string body)
        {
            Validator.CheckForEmptyString<InvalidArticleException>(body, "Body");
            Validator.CheckStringLength<InvalidArticleException>(body, BodyMinLength, BodyMaxLength, "Body");
        }

        private void ValidateTitle(string ArticleTitle)
        {
            Validator.CheckForEmptyString<InvalidArticleException>(ArticleTitle, "Title");
            Validator.CheckStringLength<InvalidArticleException>(ArticleTitle, TitleMinLength, TitleMaxLength, "Title");
        }

        private void ValidateMetaDescription(string metadescription)
        {
            Validator.CheckForEmptyString<InvalidArticleException>(metadescription, "metaDescription");
            Validator.CheckStringLength<InvalidArticleException>(metadescription, MetatagsMinLength, MetatagsMaxLength, "metaDescription");
        }
    }
}
