namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using Microsoft.Extensions.Logging;

    public class ToDoItemAddedEventHandler : IDomainEventHandler<ToDoItemAddedEvent>
    {
        private readonly ILogger<ToDoItemAddedEventHandler> logger;

        public ToDoItemAddedEventHandler(ILogger<ToDoItemAddedEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(ToDoItemAddedEvent notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Handled Domain Event: {DomainEvent}", notification.GetType().Name);

            ////throw new InvalidOperationException($"{nameof(ToDoItemAddedEventHandler)} has crashed.");
            return Task.CompletedTask;
        }
    }
}