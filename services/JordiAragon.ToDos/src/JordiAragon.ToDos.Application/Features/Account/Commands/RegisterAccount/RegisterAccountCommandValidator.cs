namespace JordiAragon.ToDos.Application.Features.Account.Commands.RegisterAccount
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Account.Commands;
    using JordiAragon.ToDos.Domain.AccountAggregate;
    using JordiAragon.ToDos.Domain.AccountAggregate.Specifications;

    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        private readonly IReadRepository<Account> accountRepository;

        public RegisterAccountCommandValidator(IReadRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;

            this.RuleFor(v => v.Firstname)
                .NotEmpty().WithMessage("Fistname is required.")
                .MaximumLength(200).WithMessage("Fistname must not exceed 200 characters.")
                .MinimumLength(2).WithMessage("Fistname must be not at least 2 characters.");

            this.RuleFor(v => v.Lastname)
                .NotEmpty().WithMessage("Lastname is required.")
                .MaximumLength(200).WithMessage("Lastname must not exceed 200 characters.")
                .MinimumLength(2).WithMessage("Lastname must be at least 2 characters.");

            this.RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("The specified email is not valid.")
                .MustAsync(this.ValidateEmailUniqueAsync).WithMessage("The specified email is not valid.");

            this.RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required."); // TODO: Add password validation rules.
        }

        private async Task<bool> ValidateEmailUniqueAsync(string email, CancellationToken cancellationToken)
        {
            var result = await this.accountRepository.CountAsync(new AccountByEmailSpec(email), cancellationToken);
            if (result > 0)
            {
                return false;
            }

            return true;
        }
    }
}