using SportBox7.Domain.Common;
using SportBox7.Domain.Models.Articles.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Models.Articles
{
    internal class ArticleData : IInitialData
    {
        public Type EntityType => typeof(Article);

        public IEnumerable<object> GetData()
        {
            return new List<Article>()
            {
                new Article("Test Title", "TestBody", "TestH1Tag","https://pik.bg", "http://goooo.com", "test Meta Description", "test meta keywords", new Category("Фитбол", "Фоотбалл"), ArticleType.NewsArticle, new DateTime(2020, 5, 11)),

                new Article("Test Title2", "TestBody2", "TestH1Tag2","https://pik.bg", "http://goooo.com", "test Meta Description", "test meta keywords", new Category("Футбол", "FootBall"), ArticleType.NewsArticle, new DateTime(2020, 5, 11))

            };
        }
    }
}
