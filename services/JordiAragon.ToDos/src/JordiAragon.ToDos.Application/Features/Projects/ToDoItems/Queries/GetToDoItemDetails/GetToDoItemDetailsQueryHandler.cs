namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItemDetails
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;

    public class GetToDoItemDetailsQueryHandler : IQueryHandler<GetToDoItemDetailsQuery, ToDoItemDetailsOutputDto>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetToDoItemDetailsQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<ToDoItemDetailsOutputDto>> Handle(GetToDoItemDetailsQuery request, CancellationToken cancellationToken)
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

            return Result.Success(this.mapper.Map<ToDoItemDetailsOutputDto>(existingToDoItem));
        }
    }
}