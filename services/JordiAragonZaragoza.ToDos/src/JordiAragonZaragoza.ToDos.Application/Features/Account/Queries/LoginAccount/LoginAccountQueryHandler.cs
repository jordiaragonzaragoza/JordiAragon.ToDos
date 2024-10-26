namespace JordiAragonZaragoza.ToDos.Application.Features.Account.Queries.LoginAccount
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Queries;
    using JordiAragonZaragoza.ToDos.Domain.AccountAggregate;
    using JordiAragonZaragoza.ToDos.Domain.AccountAggregate.Specifications;

    public class LoginAccountQueryHandler : IQueryHandler<LoginAccountQuery, AuthenticationOutputDto>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IReadRepository<Account> accountRepository;

        public LoginAccountQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IReadRepository<Account> accountRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.accountRepository = accountRepository;
        }

        public async Task<Result<AuthenticationOutputDto>> Handle(LoginAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await this.accountRepository.FirstOrDefaultAsync(new AccountByEmailSpec(request.Email), cancellationToken);
            if (account is null)
            {
                return Result.Unauthorized();
            }

            if (account.Password != request.Password)
            {
                return Result.Unauthorized();
            }

            var token = this.jwtTokenGenerator.GenerateToken(account.Id.Value, account.Firstname, account.Lastname);

            var outputDto = new AuthenticationOutputDto(account.Id.Value, account.Firstname, account.Lastname, account.Email, token); // TODO: Add mapping.

            return Result.Success(outputDto);
        }
    }
}