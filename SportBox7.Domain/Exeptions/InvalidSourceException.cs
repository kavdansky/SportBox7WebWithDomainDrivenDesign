using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    public class InvalidSourceException: BaseDomainException
    {
        public InvalidSourceException()
        {          
        }

        public InvalidSourceException(string error) => this.Error = error;
    }
}
