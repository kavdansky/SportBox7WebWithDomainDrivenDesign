using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Models.Articles
{
    public class CategoryFakes
    {
        public class CategoryDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Category);

            public object? Create(Type type)
                => new Category("Футбол", "Valid description text");

            public Priority Priority => Priority.Default;
        }
    }
}
