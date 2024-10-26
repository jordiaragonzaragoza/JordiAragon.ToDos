namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Presentation.WebApi.Contracts;
    using JordiAragon.SharedKernel.Presentation.WebApi.Helpers;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.Requests;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.Responses;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Requests;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : BaseVersionedApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetAsync(CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetProjectsQuery(), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<IEnumerable<ProjectResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("Pagination")]
        public async Task<ActionResult<PaginatedCollectionResponse<ProjectResponse>>> GetWithPaginationAsync([FromQuery] GetProjectsPaginatedRequest request, CancellationToken cancellationToken)
        {
            var query = this.Mapper.Map<GetProjectsPaginatedQuery>(request);

            var resultOutputDto = await this.Sender.Send(query, cancellationToken);

            var resultResponse = this.Mapper.Map<Result<PaginatedCollectionResponse<ProjectResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetProjectQuery(id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<ProjectResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{id}/Details")]
        public async Task<ActionResult<ProjectDetailsResponse>> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetProjectDetailsQuery(id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<ProjectDetailsResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{id}/Export-To-CSV")]
        public async Task<ActionResult> GetByIdToCsvAsync(Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetProjectToDosAsCsvFileQuery(id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<FileResponse>>(resultOutputDto);

            return this.ToFileResult(resultResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(this.Mapper.Map<CreateProjectCommand>(request), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, UpdateProjectRequest request, CancellationToken cancellationToken)
        {
           var command = this.Mapper.Map<UpdateProjectCommand>(request, opt =>
                        opt.AfterMap((_, command) => command.Id = id));

           var result = await this.Sender.Send(command, cancellationToken);

           return this.ToActionResult(result);
        }

        [HttpPut("{id}/Details")]
        public async Task<ActionResult> UpdateDetailsAsync(Guid id, UpdateProjectDetailsRequest request, CancellationToken cancellationToken)
        {
            var command = this.Mapper.Map<UpdateProjectDetailsCommand>(request, opt =>
                         opt.AfterMap((_, command) => command.Id = id));

            var result = await this.Sender.Send(command, cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new DeleteProjectCommand(id), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new DeleteProjectsCommand(), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpGet("{projectId}/ToDoItems")]
        public async Task<ActionResult<IEnumerable<ToDoItemResponse>>> GetToDosAsync(Guid projectId, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetToDoItemsQuery(projectId), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<IEnumerable<ToDoItemResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{projectId}/ToDoItems/Pagination")]
        public async Task<ActionResult<PaginatedCollectionResponse<ToDoItemResponse>>> GetToDosWithPaginationAsync(Guid projectId, [FromQuery] GetToDoItemsPaginatedRequest request, CancellationToken cancellationToken)
        {
            var query = this.Mapper.Map<GetToDoItemsPaginatedQuery>(request, opt =>
                        opt.AfterMap((_, command) => command.ProjectId = projectId));

            var resultOutputDto = await this.Sender.Send(query, cancellationToken);

            var resultResponse = this.Mapper.Map<Result<PaginatedCollectionResponse<ToDoItemResponse>>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{projectId}/ToDoItems/{id}")]
        public async Task<ActionResult<ToDoItemResponse>> GetToDoItemByIdAsync(Guid projectId, Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetToDoItemQuery(projectId, id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<ToDoItemResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpGet("{projectId}/ToDoItems/{id}/Details")]
        public async Task<ActionResult<ToDoItemDetailsResponse>> GetToDoItemDetailsByIdAsync(Guid projectId, Guid id, CancellationToken cancellationToken)
        {
            var resultOutputDto = await this.Sender.Send(new GetToDoItemDetailsQuery(projectId, id), cancellationToken);

            var resultResponse = this.Mapper.Map<Result<ToDoItemDetailsResponse>>(resultOutputDto);

            return this.ToActionResult(resultResponse);
        }

        [HttpPost("{projectId}/ToDoItems")]
        public async Task<ActionResult<Guid>> CreateToDoItemAsync(Guid projectId, CreateToDoItemRequest request, CancellationToken cancellationToken)
        {
            var command = this.Mapper.Map<CreateToDoItemCommand>(request, opt =>
                        opt.AfterMap((_, command) => command.ProjectId = projectId));

            var result = await this.Sender.Send(command, cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPut("{projectId}/ToDoItems/{id}")]
        public async Task<ActionResult> UpdateToDoItemAsync(Guid projectId, Guid id, UpdateToDoItemRequest request, CancellationToken cancellationToken)
        {
            var command = this.Mapper.Map<UpdateToDoItemCommand>(request, opt =>
                        opt.AfterMap((_, command) =>
                        {
                            command.Id = id;
                            command.ProjectId = projectId;
                        }));

            var result = await this.Sender.Send(command, cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPut("{projectId}/ToDoItems/{id}/Details")]
        public async Task<ActionResult> UpdateToDoItemDetailsAsync(Guid projectId, Guid id, UpdateToDoItemDetailRequest request, CancellationToken cancellationToken)
        {
            var command = this.Mapper.Map<UpdateToDoItemDetailCommand>(request, opt =>
                        opt.AfterMap((_, command) =>
                        {
                            command.Id = id;
                            command.ProjectId = projectId;
                        }));

            var result = await this.Sender.Send(command, cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPatch("{projectId}/ToDoItems/{id}/Set-Location")]
        public async Task<ActionResult> SetLocationToDoItemAsync(Guid projectId, Guid id, SetLocationToDoItemRequest request, CancellationToken cancellationToken)
        {
            var command = this.Mapper.Map<SetLocationToDoItemCommand>(request, opt =>
                        opt.AfterMap((_, command) =>
                        {
                            command.Id = id;
                            command.ProjectId = projectId;
                        }));

            var result = await this.Sender.Send(command, cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPatch("{projectId}/ToDoItems/{id}/Mark-As-Complete")]
        public async Task<ActionResult> MarkAsCompleteToDoItemAsync(Guid projectId, Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new MarkAsCompleteToDoItemCommand(projectId, id), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPatch("{projectId}/ToDoItems/{id}/Mark-As-Incomplete")]
        public async Task<ActionResult> MarkAsIncompleteToDoItemAsync(Guid projectId, Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new MarkAsIncompleteToDoItemCommand(projectId, id), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpDelete("{projectId}/ToDoItems/{id}")]
        public async Task<ActionResult> DeleteToDoItemByIdAsync(Guid projectId, Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new DeleteToDoItemCommand(projectId, id), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpDelete("{id}/ToDoItems")]
        public async Task<ActionResult> DeleteToDoItemsAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new DeleteToDoItemsCommand(id), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPatch("{projectId}/ToDoItems/{id}/Assign-Contributor/{contributorId}")]
        public async Task<ActionResult> AssignContributorToDoItemAsync(Guid projectId, Guid id, Guid contributorId, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new AssignContributorToDoItemCommand(projectId, id, contributorId), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPatch("{projectId}/ToDoItems/{id}/Remove-Contributor/")]
        public async Task<ActionResult> RemoveContributorToDoItemAsync(Guid projectId, Guid id, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new RemoveContributorToDoItemCommand(projectId, id), cancellationToken);

            return this.ToActionResult(result);
        }

        [HttpPatch("{projectId}/ToDoItems/{id}/Reasign-To-Project/{destinationProjectId}")]
        public async Task<ActionResult> ReasignToDoItemToProjectAsync(Guid projectId, Guid id, Guid destinationProjectId, CancellationToken cancellationToken)
        {
            var result = await this.Sender.Send(new ReasignToDoItemToProjectCommand(projectId, id, destinationProjectId), cancellationToken);

            return this.ToActionResult(result);
        }
    }
}