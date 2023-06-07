namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItemsPagination
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;

    public class GetToDoItemsPaginatedQueryHandler : IQueryHandler<GetToDoItemsPaginatedQuery, PaginatedCollectionOutputDto<ToDoItemOutputDto>>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetToDoItemsPaginatedQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        // TODO: Review. Candidate to use Dapper.
        public async Task<Result<PaginatedCollectionOutputDto<ToDoItemOutputDto>>> Handle(GetToDoItemsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.FirstOrDefaultAsync(new ProjectExtendedByIdSpec(ProjectId.Create(request.ProjectId)), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)} {request.ProjectId} not found.");
            }

            var totalCount = existingProject.Items.Count();
            if (totalCount < 1)
            {
                return Result.NotFound($"There is not any {nameof(ToDoItem)} available.");
            }

            var take = request.PageSize;
            var skip = (request.PageNumber - 1) * request.PageSize;

            var toDoItems = existingProject.Items.OrderByDescending(item => item.CreationDateOnUtc).Skip(skip).Take(take);
            if (!toDoItems.Any())
            {
                return Result.NotFound($"{nameof(ToDoItem)}/s not found. Total {nameof(ToDoItem)}/s {totalCount}");
            }

            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);
            var items = this.mapper.Map<IEnumerable<ToDoItemOutputDto>>(toDoItems);

            var result = new PaginatedCollectionOutputDto<ToDoItemOutputDto>(request.PageNumber, totalPages, totalCount, items);

            return Result.Success(result);
        }
    }
}