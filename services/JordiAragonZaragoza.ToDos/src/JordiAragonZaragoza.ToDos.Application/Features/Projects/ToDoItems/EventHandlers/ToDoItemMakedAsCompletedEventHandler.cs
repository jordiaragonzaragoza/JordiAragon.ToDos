namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using Microsoft.Extensions.Logging;

    public class ToDoItemMakedAsCompletedEventHandler : IDomainEventHandler<ToDoItemMakedAsCompletedEvent>
    {
        private readonly ILogger<ToDoItemMakedAsCompletedEventHandler> logger;

        public ToDoItemMakedAsCompletedEventHandler(ILogger<ToDoItemMakedAsCompletedEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(ToDoItemMakedAsCompletedEvent notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Handled Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}