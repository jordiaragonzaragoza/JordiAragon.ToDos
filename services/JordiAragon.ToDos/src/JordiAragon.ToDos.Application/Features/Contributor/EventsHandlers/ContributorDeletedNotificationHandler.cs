namespace JordiAragon.ToDos.Application.Features.Contributor.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Events;
    using Microsoft.Extensions.Logging;

    public class ContributorDeletedNotificationHandler : IApplicationEventNotificationHandler<ContributorDeletedNotification>
    {
        private readonly ILogger<ContributorDeletedNotificationHandler> logger;

        public ContributorDeletedNotificationHandler(
            ILogger<ContributorDeletedNotificationHandler> logger)
        {
            this.logger = Guard.Against.Null(logger, nameof(logger));
        }

        public Task Handle(ContributorDeletedNotification notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Handled Notification: {ApplicationEvent}", notification.GetType().Name);

            // TODO: Use Send service to notify the admin.
            return Task.CompletedTask;
        }
    }
}