namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Accounts.Responses
{
    using System;

    public record class AuthenticationResponse(Guid Id, string Fistname, string Lastname, string Email, string Token);
}