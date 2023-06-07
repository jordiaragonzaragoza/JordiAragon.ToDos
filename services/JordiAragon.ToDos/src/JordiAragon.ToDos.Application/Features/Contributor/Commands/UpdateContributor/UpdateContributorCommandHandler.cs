namespace JordiAragon.ToDos.Application.Features.Contributors.Commands.UpdateContributor
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Ardalis.GuardClauses;

    public class UpdateContributorCommandHandler : ICommandHandler<UpdateContributorCommand>
    {
        private readonly IRepository<Contributor> repositoryContributor;

        public UpdateContributorCommandHandler(IRepository<Contributor> repositoryContributor)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
        }

        public async Task<Result> Handle(UpdateContributorCommand request, CancellationToken cancellationToken)
        {
            var existingContributor = await this.repositoryContributor.GetByIdAsync(ContributorId.Create(request.Id), cancellationToken);
            if (existingContributor is null)
            {
                return Result.NotFound($"{nameof(Contributor)}: {request.Id} not found.");
            }

            existingContributor.UpdateName(request.Name);

            await this.repositoryContributor.UpdateAsync(existingContributor, cancellationToken);

            return Result.Success();
        }
    }
}