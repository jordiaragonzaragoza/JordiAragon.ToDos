namespace JordiAragon.ToDos.Application.Features.Contributors.Queries.GetContributors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragon.ToDos.Domain.ContributorAggregate;

    public class GetContributorQueryHandler : IQueryHandler<GetContributorQuery, ContributorOutputDto>
    {
        private readonly IReadRepository<Contributor> repositoryContributor;
        private readonly IMapper mapper;

        public GetContributorQueryHandler(
            IReadRepository<Contributor> repositoryContributor,
            IMapper mapper)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
            this.mapper = Guard.Against.Null(mapper, nameof(mapper));
        }

        public async Task<Result<ContributorOutputDto>> Handle(GetContributorQuery request, CancellationToken cancellationToken)
        {
            var contributor = await this.repositoryContributor.GetByIdAsync(ContributorId.Create(request.Id), cancellationToken);
            if (contributor is null)
            {
                return Result.NotFound($"{nameof(Contributor)} {request.Id} not found.");
            }

            return Result.Success(this.mapper.Map<ContributorOutputDto>(contributor));
        }
    }
}