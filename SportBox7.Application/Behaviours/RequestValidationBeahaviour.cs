namespace SportBox7.Application.Behaviours
{
    using FluentValidation;
    using MediatR;
    using SportBox7.Application.Exceptions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestValidationBeahaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBeahaviour(IEnumerable<IValidator<TRequest>> validators)
            => this.validators = validators;
        

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = this
                .validators
                .Select(v => v.Validate(context))
                .SelectMany(request => request.Errors)
                .Where(f => f != null)
                .ToList();

            if (errors.Count != 0)
            {
                throw new ModelValidationException(errors);
            }

            return next();
        }
    }
}
