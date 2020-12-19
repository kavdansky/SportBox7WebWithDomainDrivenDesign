using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    public class InvalidEditorException: BaseDomainException
    {
        public InvalidEditorException()
        {
        }

        public InvalidEditorException(string error) => this.Error = error;
    }
}
