namespace SportBox7.Domain.Factories.Articles
{
    using SportBox7.Domain.Exeptions;
    using SportBox7.Domain.Models.Articles;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Domain.Models.Sources;
    using System;

    internal class ArticleFactory : IArticleFactory
    {
        private string title = default!;
        private string body = default!;
        private string h1Tag = default!;
        private string imageUrl = default!;
        private string imageCredit = default!;
        private string metaDescription = default!;
        private string metaKeywords = default!;
        private Category category = default!;
        private ArticleType articleType = default!;
        private DateTime targetDate = default!;
        private Source source = default!;

        private bool isTitleSet;
        private bool isBodyset;
        private bool isH1TagSet;
        private bool isImageUrlSet;
        private bool isImageCreditSet;
        private bool isMetaDescriptionSet;
        private bool isMetaKeywordsSet;
        private bool isCategorySet;
        private bool isArticleTypeSet;
        private bool isTargetDateSet;
        private bool isSourceSet;



        public IArticleFactory WithArticleType(ArticleType articleType)
        {
            this.articleType = articleType;
            this.isArticleTypeSet = true;
            return this;
        }

        public IArticleFactory WithBody(string body)
        {
            this.body = body;
            this.isBodyset = true;
            return this;
        }

        public IArticleFactory WithCategory(Category category)
        {
            this.category = category;
            this.isCategorySet = true;
            return this;
        }

        public IArticleFactory WithH1Tag(string h1Tag)
        {
            this.h1Tag = h1Tag;
            this.isH1TagSet = true;
            return this;
        }

        public IArticleFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            this.isImageUrlSet = true;
            return this;
        }

        public IArticleFactory WithMetaDescription(string metaDescription)
        {
            this.metaDescription = metaDescription;
            this.isMetaDescriptionSet = true;
            return this;
        }

        public IArticleFactory WithMetaKeywords(string metaKeywords)
        {
            this.metaKeywords = metaKeywords;
            this.isMetaKeywordsSet = true;
            return this;
        }

        public IArticleFactory WithImageCredit(string imageCredit)
        {
            this.imageCredit = imageCredit;
            this.isImageCreditSet = true;
            return this;
        }

        public IArticleFactory WithSource(Source source)
        {
            this.source = source;
            this.isSourceSet = true;
            return this;
        }

        public IArticleFactory WithTargetDate(DateTime targetDate)
        {
            this.isTargetDateSet = true;
            this.targetDate = targetDate;
            return this;
        }

        public IArticleFactory WithTitle(string title)
        {
            this.isTitleSet = true;
            this.title = title;
            return this;
        }

        public Article Build()
        {
            if (isTitleSet== false || isBodyset == false || isH1TagSet == false || isImageUrlSet == false || isImageCreditSet == false || isMetaDescriptionSet== false || isMetaKeywordsSet == false || isCategorySet == false || isArticleTypeSet == false || isSourceSet == false || isArticleTypeSet == false || isTargetDateSet == false)
            {
                
                throw new InvalidArticleException("Title, Body, H1Tag, ImageUrl, ImageCredit, MetaDescription, MetaKeywords, Category and TargetDate must have value!");
            }

            return new Article(this.title, this.body, this.h1Tag, this.imageUrl, this.imageCredit, this.metaDescription, this.metaKeywords, this.category, this.articleType, this.targetDate, this.source);
        }
    }
}
