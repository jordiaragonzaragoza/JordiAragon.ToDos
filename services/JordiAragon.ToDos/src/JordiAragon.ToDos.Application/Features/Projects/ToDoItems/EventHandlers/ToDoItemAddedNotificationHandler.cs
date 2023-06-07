namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Events.Notifications;
    using Microsoft.Extensions.Logging;

    public class ToDoItemAddedNotificationHandler : IDomainEventNotificationHandler<ToDoItemAddedNotification>
    {
        private readonly ILogger<ToDoItemAddedNotificationHandler> logger;

        public ToDoItemAddedNotificationHandler(ILogger<ToDoItemAddedNotificationHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(ToDoItemAddedNotification notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Handled Notification: {DomainEvent}", notification.GetType().Name);

            // TODO: Notify the admin.
            return Task.CompletedTask;
        }
    }
}