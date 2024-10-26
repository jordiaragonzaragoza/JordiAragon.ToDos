namespace JordiAragonZaragoza.ToDos.Application.Features.Contributors.Queries.GetContributors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Ardalis.GuardClauses;

    public class GetContributorsQueryHandler : IQueryHandler<GetContributorsQuery, IEnumerable<ContributorOutputDto>>
    {
        private readonly IReadRepository<Contributor> repositoryContributor;
        private readonly IMapper mapper;

        public GetContributorsQueryHandler(
            IReadRepository<Contributor> repositoryContributor,
            IMapper mapper)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
            this.mapper = Guard.Against.Null(mapper, nameof(mapper));
        }

        public async Task<Result<IEnumerable<ContributorOutputDto>>> Handle(GetContributorsQuery request, CancellationToken cancellationToken)
        {
            var contributors = await this.repositoryContributor.ListAsync(cancellationToken);
            if (!contributors.Any())
            {
                return Result.NotFound($"{nameof(Contributor)}/s not found.");
            }

            return Result.Success(this.mapper.Map<IEnumerable<ContributorOutputDto>>(contributors));
        }
    }
}