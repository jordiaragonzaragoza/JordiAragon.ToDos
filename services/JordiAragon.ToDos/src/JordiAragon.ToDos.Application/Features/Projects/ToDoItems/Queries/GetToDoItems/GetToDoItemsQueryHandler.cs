namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItems
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class GetToDoItemsQueryHandler : IQueryHandler<GetToDoItemsQuery, IEnumerable<ToDoItemOutputDto>>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetToDoItemsQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<ToDoItemOutputDto>>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.FirstOrDefaultAsync(new ProjectWithItemsByIdSpec(ProjectId.Create(request.ProjectId)), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.ProjectId} not found.");
            }

            if (!existingProject.Items.Any())
            {
                return Result.NotFound($"There is not any {nameof(ToDoItem)} avaliable for {nameof(Project)} {request.ProjectId}.");
            }

            return Result.Success(this.mapper.Map<IEnumerable<ToDoItemOutputDto>>(existingProject.Items));
        }
    }
}