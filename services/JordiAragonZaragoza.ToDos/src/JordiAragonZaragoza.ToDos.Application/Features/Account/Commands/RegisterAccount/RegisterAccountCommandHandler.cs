namespace JordiAragonZaragoza.ToDos.Application.Features.Account.Commands.RegisterAccount
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Queries;
    using JordiAragonZaragoza.ToDos.Domain.AccountAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using Volo.Abp.Guids;

    public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand, AuthenticationOutputDto>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IRepository<Account> accountRepository;
        private readonly IGuidGenerator guidGenerator;

        public RegisterAccountCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IRepository<Account> accountRepository,
            IGuidGenerator guidGenerator)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.accountRepository = accountRepository;
            this.guidGenerator = guidGenerator;
        }

        public async Task<Result<AuthenticationOutputDto>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var newAccount = Account.Create(AccountId.Create(this.guidGenerator.Create()), request.Firstname, request.Lastname, request.Email, request.Password);

            var result = await this.accountRepository.AddAsync(newAccount, cancellationToken);

            if (result is null)
            {
                return Result.Error($"{nameof(Account)}: {newAccount.Id} was not created.");
            }

            var token = this.jwtTokenGenerator.GenerateToken(newAccount.Id.Value, newAccount.Firstname, newAccount.Lastname);

            var outputDto = new AuthenticationOutputDto(newAccount.Id.Value, newAccount.Firstname, newAccount.Lastname, newAccount.Email, token); // TODO: Add mapping.

            return Result.Success(outputDto);
        }
    }
}