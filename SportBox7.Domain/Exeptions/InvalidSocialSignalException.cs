using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    public class InvalidSocialSignalException: BaseDomainException
    {
        public InvalidSocialSignalException()
        {

        }

        public InvalidSocialSignalException(string error) => this.Error = error;
    }   
}
