namespace SportBox7.Application.Features.Sources.Commands.Create
{
    using FluentValidation;
    using static SportBox7.Domain.Models.ModelConstants.Source;
    using static SportBox7.Domain.Models.ModelConstants.Common;

    public class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
    {
        public CreateSourceCommandValidator()
        {
            this.RuleFor(u => u.SourceName)
                .MinimumLength(SourceNameMinLength)
                .MaximumLength(SourceNameMinLength)
                .NotEmpty();

            this.RuleFor(u => u.SourceImageUrl)
                .MinimumLength(MinUrlLength)
                .MaximumLength(MaxUrlLength)
                .Matches(UrlRregularExpression)
                .NotEmpty();

            this.RuleFor(u => u.SourceUrl)
                .MinimumLength(MinUrlLength)
                .MaximumLength(MaxUrlLength)
                .Matches(UrlRregularExpression)
                .NotEmpty();
        }
    }
}
