namespace JordiAragon.ToDos.Application.Features.Projects.Queries.GetProjectsPaginated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class GetProjectsPaginatedQueryHandler : IQueryHandler<GetProjectsPaginatedQuery, PaginatedCollectionOutputDto<ProjectOutputDto>>
    {
        private readonly IReadRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public GetProjectsPaginatedQueryHandler(
            IReadRepository<Project> projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        public async Task<Result<PaginatedCollectionOutputDto<ProjectOutputDto>>> Handle(GetProjectsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await this.projectRepository.CountAsync(cancellationToken);
            if (totalCount < 1)
            {
                return Result.NotFound($"There is not any {nameof(Project)} available.");
            }

            var take = request.PageSize;
            var skip = (request.PageNumber - 1) * request.PageSize;

            var projects = await this.projectRepository.ListAsync(new ProjectsPaginatedSpec(skip, take), cancellationToken);
            if (!projects.Any())
            {
                return Result.NotFound($"{nameof(Project)}/s not found. Total {nameof(Project)}/s {totalCount}");
            }

            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);
            var items = this.mapper.Map<IEnumerable<ProjectOutputDto>>(projects);

            var result = new PaginatedCollectionOutputDto<ProjectOutputDto>(request.PageNumber, totalPages, totalCount, items);

            return Result.Success(result);
        }
    }
}