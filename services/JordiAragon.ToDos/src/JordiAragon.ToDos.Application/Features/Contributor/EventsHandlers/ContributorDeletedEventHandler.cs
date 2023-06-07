namespace JordiAragon.ToDos.Application.Features.Contributor.EventHandlers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Events;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;

    public class ContributorDeletedEventHandler : IApplicationEventHandler<ContributorDeletedEvent>
    {
        private readonly IRepository<Project> projectRepository;

        public ContributorDeletedEventHandler(IRepository<Project> projectRepository)
        {
            this.projectRepository = Guard.Against.Null(projectRepository, nameof(projectRepository));
        }

        public async Task Handle(ContributorDeletedEvent notification, CancellationToken cancellationToken)
        {
            var projectSpec = new ProjectsWithItemsByContributorIdSpec(ContributorId.Create(notification.ContributorId));
            var projects = await this.projectRepository.ListAsync(projectSpec, cancellationToken);
            foreach (var project in projects)
            {
                project.Items
                  .Where(item => item.ContributorId == ContributorId.Create(notification.ContributorId))
                  .ToList()
                  .ForEach(item => item.RemoveContributor());

                await this.projectRepository.UpdateAsync(project, cancellationToken);
            }
        }
    }
}