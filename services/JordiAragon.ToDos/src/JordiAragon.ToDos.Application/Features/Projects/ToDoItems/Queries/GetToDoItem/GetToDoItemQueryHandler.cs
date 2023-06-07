namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItem
{
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

    public class GetToDoItemQueryHandler : IQueryHandler<GetToDoItemQuery, ToDoItemOutputDto>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetToDoItemQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<ToDoItemOutputDto>> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
        {
            var existingProject = await this.projectRepository.FirstOrDefaultAsync(new ProjectWithItemsByIdSpec(ProjectId.Create(request.ProjectId)), cancellationToken);
            if (existingProject is null)
            {
                return Result.NotFound($"{nameof(Project)}: {request.ProjectId} not found.");
            }

            var existingToDoItem = existingProject.Items.FirstOrDefault(item => item.Id == ToDoItemId.Create(request.Id));
            if (existingToDoItem is null)
            {
                return Result.NotFound($"{nameof(ToDoItem)}: {request.Id} not found.");
            }

            return Result.Success(this.mapper.Map<ToDoItemOutputDto>(existingToDoItem));
        }
    }
}