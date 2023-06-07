namespace JordiAragon.ToDos.Application.Features.Contributors.Queries.GetContributors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ContributorAggregate.Specifications;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Ardalis.GuardClauses;

    public class GetContributorsPaginatedQueryHandler : IQueryHandler<GetContributorsPaginatedQuery, PaginatedCollectionOutputDto<ContributorOutputDto>>
    {
        private readonly IReadRepository<Contributor> repositoryContributor;
        private readonly IMapper mapper;

        public GetContributorsPaginatedQueryHandler(
            IReadRepository<Contributor> repositoryContributor,
            IMapper mapper)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
            this.mapper = Guard.Against.Null(mapper, nameof(mapper));
        }

        public async Task<Result<PaginatedCollectionOutputDto<ContributorOutputDto>>> Handle(GetContributorsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await this.repositoryContributor.CountAsync(cancellationToken);
            if (totalCount < 1)
            {
                return Result.NotFound($"There is not any {nameof(Contributor)} available.");
            }

            var take = request.PageSize;
            var skip = (request.PageNumber - 1) * request.PageSize;

            var projects = await this.repositoryContributor.ListAsync(new ContributorsPaginatedSpec(skip, take), cancellationToken);
            if (!projects.Any())
            {
                return Result.NotFound($"{nameof(Contributor)}/s not found. Total {nameof(Contributor)}/s {totalCount}");
            }

            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);
            var items = this.mapper.Map<IEnumerable<ContributorOutputDto>>(projects);

            var result = new PaginatedCollectionOutputDto<ContributorOutputDto>(request.PageNumber, totalPages, totalCount, items);

            return Result.Success(result);
        }
    }
}