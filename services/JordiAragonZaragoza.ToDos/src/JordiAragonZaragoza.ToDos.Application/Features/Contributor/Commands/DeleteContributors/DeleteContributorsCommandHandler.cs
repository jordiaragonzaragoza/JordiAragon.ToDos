namespace JordiAragonZaragoza.ToDos.Application.Features.Contributors.Commands.DeleteContributors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Ardalis.GuardClauses;

    public class DeleteContributorsCommandHandler : ICommandHandler<DeleteContributorsCommand>
    {
        private readonly IRepository<Contributor> repositoryContributor;

        public DeleteContributorsCommandHandler(IRepository<Contributor> repositoryContributor)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
        }

        public async Task<Result> Handle(DeleteContributorsCommand request, CancellationToken cancellationToken)
        {
            var result = await this.repositoryContributor.ListAsync(cancellationToken);
            await this.repositoryContributor.DeleteRangeAsync(result, cancellationToken);

            return Result.Success();
        }
    }
}