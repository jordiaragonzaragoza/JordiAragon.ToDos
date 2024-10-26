namespace JordiAragonZaragoza.ToDos.Infrastructure.Identity
{
    using System.Linq;
    using Ardalis.Result;
    using Microsoft.AspNetCore.Identity;

    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Error(result.Errors.Select(e => e.Description).ToArray());
        }
    }
}