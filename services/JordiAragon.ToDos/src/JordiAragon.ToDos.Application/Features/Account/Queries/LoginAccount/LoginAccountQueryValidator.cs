namespace JordiAragon.ToDos.Application.Features.Account.Queries.LoginAccount
{
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Account.Queries;

    public class LoginAccountQueryValidator : AbstractValidator<LoginAccountQuery>
    {
        public LoginAccountQueryValidator()
        {
            this.RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("The specified email is not valid.");

            this.RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}