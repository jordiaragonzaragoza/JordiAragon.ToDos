namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Queries
{
    using System;

    public record class AuthenticationOutputDto(Guid Id, string Fistname, string Lastname, string Email, string Token);
}