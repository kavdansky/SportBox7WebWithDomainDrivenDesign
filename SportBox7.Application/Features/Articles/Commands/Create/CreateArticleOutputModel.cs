using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Application.Features.Articles.Commands.Create
{
    public class CreateArticleOutputModel
    {
        public CreateArticleOutputModel(int Id)
           => this.Id = Id;

        public int Id { get; }
    }
}
