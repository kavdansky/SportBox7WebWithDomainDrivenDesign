using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    public class InvalidArticleException : BaseDomainException
    {
        public InvalidArticleException()
        {
        }

        public InvalidArticleException(string error) => this.Error = error;
    }
}
