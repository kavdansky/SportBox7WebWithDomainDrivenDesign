namespace SportBox7.Domain.Models.Articles
{
    using Bogus;
    using FakeItEasy;
    using SportBox7.Domain.Common;
    using SportBox7.Domain.Models.Articles.Enums;
    using SportBox7.Domain.Models.Categories;
    using SportBox7.Domain.Models.Sources;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArticleFakes
    {
        public class ArticleDummyFactory : IDummyFactory
        {
            
            public bool CanCreate(Type type) => type == typeof(Article);

            public object? Create(Type type) => Data.GetArticle();

            public Priority Priority => Priority.Default;
        }
        public static class Data
            {
                public static IEnumerable<Article> GetArticles(int count = 10)
                    => Enumerable
                        .Range(1, count)
                        .Select(i => GetArticle(i))
                        .Concat(Enumerable
                            .Range(count + 1, count * 2)
                            .Select(i => GetArticle(i)))
                        .ToList();

                public static Article GetArticle(int id = 1)
                    => new Faker<Article>()
                        .CustomInstantiator(f => new Article(
                            f.Lorem.Letter(10),
                            f.Lorem.Letter(40),
                            f.Lorem.Letter(10),
                            f.Image.PicsumUrl(),
                            f.Internet.Url(),
                            f.Lorem.Letter(20),
                            f.Lorem.Letter(20),
                            new Category("Футбол", "Football"),
                            ArticleType.NewsArticle,
                            f.Date.Between(new DateTime(2018,11,11), new DateTime(2020,10,10)),
                                new Source(f.Lorem.Letter(10), f.Internet.Url(), f.Internet.Url())))
                        .Generate()
                        .SetId(id);
            }
    }
}
