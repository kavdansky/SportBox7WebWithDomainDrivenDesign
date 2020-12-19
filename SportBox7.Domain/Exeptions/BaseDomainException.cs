using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Exeptions
{
    using System;

    public abstract class BaseDomainException : Exception
    {
        private string? error;

        public string Error
        {
            get => this.error ?? base.Message;
            set => this.error = value;
        }
    }
}
