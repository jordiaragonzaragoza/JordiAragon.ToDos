namespace JordiAragonZaragoza.ToDos.Application.Features.Contributors.Commands.DeleteContributor
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Application.Events.Services;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Events;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;

    public class DeleteContributorCommandHandler : ICommandHandler<DeleteContributorCommand>
    {
        private readonly IRepository<Contributor> repositoryContributor;
        private readonly IApplicationEventsDispatcherService applicationEventsDispatcherService;

        public DeleteContributorCommandHandler(
            IRepository<Contributor> repositoryContributor,
            IApplicationEventsDispatcherService applicationEventsDispatcherService)
        {
            this.repositoryContributor = Guard.Against.Null(repositoryContributor, nameof(repositoryContributor));
            this.applicationEventsDispatcherService = Guard.Against.Null(applicationEventsDispatcherService, nameof(applicationEventsDispatcherService));
        }

        public async Task<Result> Handle(DeleteContributorCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.repositoryContributor.GetByIdAsync(ContributorId.Create(request.Id), cancellationToken);
            if (entity is null)
            {
                return Result.NotFound($"{nameof(Contributor)}: {request.Id} not found.");
            }

            // Event dispatched before to clean ContributorIds on ClientSetNull.
            var @event = new ContributorDeletedEvent(request.Id);
            await this.applicationEventsDispatcherService.DispatchEventsAsync(new List<ContributorDeletedEvent> { @event }, cancellationToken);

            await this.repositoryContributor.DeleteAsync(entity, cancellationToken);

            return Result.Success();
        }
    }
}