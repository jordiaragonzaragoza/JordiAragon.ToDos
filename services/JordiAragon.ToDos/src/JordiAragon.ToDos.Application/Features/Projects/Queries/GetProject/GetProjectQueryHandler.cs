namespace JordiAragon.ToDos.Application.Features.Projects.Queries.GetProjects
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectOutputDto>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetProjectQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<ProjectOutputDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.FirstOrDefaultAsync(new ProjectExtendedByIdSpec(ProjectId.Create(request.Id)), cancellationToken);
            if (project is null)
            {
                return Result.NotFound($"{nameof(Project)} {request.Id} not found.");
            }

            return Result.Success(this.mapper.Map<ProjectOutputDto>(project));
        }
    }
}