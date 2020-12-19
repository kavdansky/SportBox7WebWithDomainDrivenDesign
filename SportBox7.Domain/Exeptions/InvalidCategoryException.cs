using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    public class InvalidCategoryException: BaseDomainException
    {
        public InvalidCategoryException()
        {

        }

        public InvalidCategoryException(string error) => this.Error = error;
    }
}
