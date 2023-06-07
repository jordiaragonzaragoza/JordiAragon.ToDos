namespace JordiAragon.ToDos.Application.Features.Contributors.Commands.CreateContributor
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using Volo.Abp.Guids;

    public class CreateContributorCommandHandler : ICommandHandler<CreateContributorCommand, Guid>
    {
        private readonly IRepository<Contributor> repositoryContributor;
        private readonly IGuidGenerator guidGenerator;

        public CreateContributorCommandHandler(
            IRepository<Contributor> repositoryContributor,
            IGuidGenerator guidGenerator)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
            this.guidGenerator = Guard.Against.Null(guidGenerator, nameof(guidGenerator));
        }

        public async Task<Result<Guid>> Handle(CreateContributorCommand request, CancellationToken cancellationToken)
        {
            var newContributor = Contributor.Create(
                id: ContributorId.Create(this.guidGenerator.Create()),
                name: request.Name);

            var result = await this.repositoryContributor.AddAsync(newContributor, cancellationToken);

            if (result is null)
            {
                return Result.Error($"{nameof(Contributor)}: {newContributor.Id.Value} was not created.");
            }

            return Result.Success(result.Id.Value);
        }
    }
}