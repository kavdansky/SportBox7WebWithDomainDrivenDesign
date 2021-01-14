namespace SportBox7.Startup.Specs
{
    using MyTested.AspNetCore.Mvc;
    using SportBox7.Application.Features.Articles.Queries.Category;
    using SportBox7.Domain.Models.Editors;
    using System.Linq;
    using FluentAssertions;
    using Xunit;
   

    public class ArticleControllerSpecs
    {
       // [Fact]
       // public void SearchShouldHaveCorrectAttributes()
       //     => MyController<ArticlesController>
       //         .Calling(c => c.Search(With.Default<ListArticlesByCategoryQuery>()))
       //
       //         .ShouldHave()
       //         .ActionAttributes(attr => attr
       //             .RestrictingForHttpMethod(HttpMethod.Get));
       //
       // [Theory]
       // [InlineData(2)]
       // public void SearchShouldReturnAllArticlesWithoutAQuery(int totalArticles)
       //     => MyPipeline
       //         .Configuration()
       //         .ShouldMap("/Articles")
       //
       //
       //         .To<ArticlesController>(c => c.Search(With.Empty<ListArticlesByCategoryQuery>()))
       //         .Which(instance => instance
       //             .WithData(EditorFakes.Data.GetEditor(totalArticles: totalArticles)))
       //
       //         .ShouldReturn()
       //         .ActionResult<SearchArticleOutputModel>(result => result
       //             .Passing(model => model
       //                 .Articles.Count().Should().Be(totalArticles)));
       //
       // 
       // [Theory]
       // [InlineData("Football")]
       // public void SearchShouldReturnFilteredArticlesByCategoryWithQuery(string category)
       //     => MyPipeline
       //         .Configuration()
       //         .ShouldMap($"/Articles?category={category}")
       //
       //         .To<ArticlesController>(c => c.Search(new ListArticlesByCategoryQuery { Category = category }))
       //         .Which(instance => instance
       //             .WithData(EditorFakes.Data.GetEditor()))
       //
       //         .ShouldReturn()
       //         .ActionResult<SearchArticleOutputModel>(result => result
       //             .Passing(model =>
       //             {
       //                 model.Articles.Count().Should().Be(10);
       //                 model.Articles.First().Category.Should().Be(category);
       //             }));
    }
}
