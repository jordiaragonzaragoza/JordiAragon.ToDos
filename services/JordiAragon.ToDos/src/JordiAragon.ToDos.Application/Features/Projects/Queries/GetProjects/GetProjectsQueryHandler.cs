namespace JordiAragon.ToDos.Application.Features.Projects.Queries.GetProjects
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class GetProjectsQueryHandler : IQueryHandler<GetProjectsQuery, IEnumerable<ProjectOutputDto>>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetProjectsQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProjectOutputDto>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await this.projectRepository.ListAsync(cancellationToken);
            if (!projects.Any())
            {
                return Result.NotFound($"{nameof(Project)}/s not found.");
            }

            return Result.Success(this.mapper.Map<IEnumerable<ProjectOutputDto>>(projects));
        }
    }
}