namespace SportBox7.Domain.Models.Editors
{
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using Common;
    using static Articles.ArticleFakes.Data;
   

    public class EditorFakes
    {
        public static class Data
        {
            public static IEnumerable<Editor> GetEditors(int count = 10)
                => (IEnumerable<Editor>)Enumerable
                    .Range(1, count)
                    .Select(GetEditor)
                    .ToList();
           
            public static Editor GetEditor(int id = 1, int totalArticles = 10)
            {
                var editor = new Faker<Editor>()
                    .CustomInstantiator(f => new Editor(
                        $"Editor{id}",
                        f.Phone.PhoneNumber("+########")))
                    .Generate()
                    .SetId(id);
           
                foreach (var article in GetArticles().Take(totalArticles))
                {
                    editor.AddArticle(article);
                }
           
                return editor;
            }
        }
    }
}
