﻿namespace SportBox7.Application.Features.Identity.Commands.CreateUser
{
    using FluentValidation;

    using static SportBox7.Domain.Models.ModelConstants.Common; 

    public class EditUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public EditUserCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MaximumLength(MaxNameLength)
                .MinimumLength(MinNameLength)
                .NotEmpty();

            this.RuleFor(u => u.FirstName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.LastName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
        }
    }
}
