namespace SportBox7.Application.Features.Sources.Commands.Create
{
    using FluentValidation;
    using static SportBox7.Domain.Models.ModelConstants.Source;
    using static SportBox7.Domain.Models.ModelConstants.Common;
    using System;

    public class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
    {
        public CreateSourceCommandValidator()
        {
            this.RuleFor(u => u.SourceName)
                .MinimumLength(SourceNameMinLength)
                .MaximumLength(SourceNameMaxLength)
                .NotEmpty();

            this.RuleFor(u => u.SourceImageUrl)
                .MinimumLength(MinUrlLength)
                .MaximumLength(MaxUrlLength)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .NotEmpty();

            this.RuleFor(u => u.SourceUrl)
                .MinimumLength(MinUrlLength)
                .MaximumLength(MaxUrlLength)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .NotEmpty();
        }
    }
}
