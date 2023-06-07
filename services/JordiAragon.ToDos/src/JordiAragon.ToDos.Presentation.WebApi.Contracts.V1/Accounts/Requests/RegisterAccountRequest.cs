namespace JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Accounts.Requests
{
    public record class RegisterAccountRequest(string Firstname, string Lastname, string Email, string Password);
}