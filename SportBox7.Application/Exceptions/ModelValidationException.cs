namespace SportBox7.Application.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation.Results;

    public class ModelValidationException : Exception
    {
        public ModelValidationException()
            : base("One or more validation errors have occurred.")
            => this.Errors = new List<string>();

        public ModelValidationException(IEnumerable<ValidationFailure> errors)
            : this()
        {
            

            foreach (var error in errors)
            {
                this.Errors.Add(error.ErrorMessage);
            }
        }

        public List<string> Errors { get; }
    }
}
