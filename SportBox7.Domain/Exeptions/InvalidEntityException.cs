using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    public class InvalidEntityException: Exception
    {
        public InvalidEntityException(string message)
            :base(message)
        {

        }
    }
}
