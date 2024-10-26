namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Presentation.WebApi.Contracts;
    using JordiAragon.SharedKernel.Presentation.WebApi.Helpers;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Contributors.Requests;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Contributors.Responses;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses;
    using Microsoft.AspNetCore.Mvc;

    public class ContributorsController : BaseVersionedApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContributorResponse>>> GetAsync(CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetContributorsQuery(), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<IEnumerable<ContributorResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("Pagination")]
        public async Task<ActionResult<PaginatedCollectionResponse<ContributorResponse>>> GetWithPaginationAsync([FromQuery] GetContributorsPaginatedRequest request, CancellationToken cancellationToken)
        {
            var query = this.Mapper.Map<GetContributorsPaginatedQuery>(request);

            var resultOutputDto = await this.Sender.Send(query, cancellationToken);

            var resultResponse = this.Mapper.Map<Result<PaginatedCollectionResponse<ContributorResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContributorResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetContributorQuery(id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<ContributorResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{id}/ToDoItems")]
        public async Task<ActionResult<IEnumerable<ToDoItemResponse>>> GetToDosAsync(Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetContributorToDoItemsQuery(id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<IEnumerable<ToDoItemResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateContributorRequest request, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(this.Mapper.Map<CreateContributorCommand>(request), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, UpdateContributorRequest request, CancellationToken cancellationToken)
        {
            var command = this.Mapper.Map<UpdateContributorCommand>(request, opt =>
                         opt.AfterMap((_, command) => command.Id = id));

            var result = await this.Sender.Send(command, cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new DeleteContributorCommand(id), cancellationToken);

            return this.ToActionResult(result);
        }
    }
}