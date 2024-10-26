namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Queries.GetProjectDetails
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class GetProjectDetailsQueryHandler : IQueryHandler<GetProjectDetailsQuery, ProjectDetailsOutputDto>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetProjectDetailsQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<ProjectDetailsOutputDto>> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.FirstOrDefaultAsync(new ProjectExtendedByIdSpec(ProjectId.Create(request.Id)), cancellationToken);
            if (project is null)
            {
                return Result.NotFound($"{nameof(Project)} {request.Id} not found.");
            }

            return Result.Success(this.mapper.Map<ProjectDetailsOutputDto>(project));
        }
    }
}