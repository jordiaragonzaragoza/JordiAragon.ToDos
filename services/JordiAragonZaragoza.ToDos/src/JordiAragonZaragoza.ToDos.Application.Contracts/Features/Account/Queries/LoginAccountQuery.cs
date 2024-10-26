namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Queries
{
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class LoginAccountQuery(string Email, string Password) : IQuery<AuthenticationOutputDto>;
}