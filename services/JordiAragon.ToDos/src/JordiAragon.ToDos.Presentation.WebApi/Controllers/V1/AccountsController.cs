namespace JordiAragon.ToDos.Presentation.WebApi.Controllers.V1
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Presentation.WebApi.Helpers;
    using JordiAragon.ToDos.Application.Contracts.Features.Account.Commands;
    using JordiAragon.ToDos.Application.Contracts.Features.Account.Queries;
    using JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Accounts.Requests;
    using JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Accounts.Responses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AccountsController : BaseVersionedApiController
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<AuthenticationResponse>> RegisterAsync(RegisterAccountRequest request, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(this.Mapper.Map<RegisterAccountCommand>(request), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<AuthenticationResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> LoginAsync([FromBody] LoginAccountRequest request, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(this.Mapper.Map<LoginAccountQuery>(request), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<AuthenticationResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        // TODO: Complete.
        /*
        [HttpPatch("Logout")]
        public Task<ActionResult> LogoutAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetAsync(CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetAccountsQuery(), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<IEnumerable<AccountResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("Pagination")]
        public async Task<ActionResult<PaginatedCollectionResponse<AccountResponse>>> GetWithPaginationAsync([FromQuery] GetAccountsPaginatedRequest request, CancellationToken cancellationToken)
        {
            var query = this.Mapper.Map<GetAccountsPaginatedQuery>(request);

            var resultOutputDto = await this.Sender.Send(query, cancellationToken);

            var resultResponse = this.Mapper.Map<Result<PaginatedCollectionResponse<AccountResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetAccountQuery(id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<AccountResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }*/
    }
}