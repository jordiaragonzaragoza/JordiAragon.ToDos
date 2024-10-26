namespace JordiAragonZaragoza.ToDos.Presentation.IntegrationMessages.Consumers.ToDos.V1.Projects.ToDoItems
{
    using System.Threading.Tasks;
    using JordiAragonZaragoza.MessageHub.Application.Contracts.IntegrationMessages.V1.Projects.ToDoItems;
    using JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.Interfaces;
    using MassTransit;
    using Microsoft.Extensions.Logging;

    public class ContributorNotifiedToDoItemExpiredEventConsumer : IEventConsumer<ContributorNotifiedToDoItemExpiredEvent>
    {
        private readonly ILogger<ContributorNotifiedToDoItemExpiredEventConsumer> logger;

        public ContributorNotifiedToDoItemExpiredEventConsumer(
            ILogger<ContributorNotifiedToDoItemExpiredEventConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<ContributorNotifiedToDoItemExpiredEvent> context)
        {
            // TODO: Complete. Add MediatR command to implement use case.
            this.logger.LogInformation("Consume Event {@event}: {@Message}", nameof(ContributorNotifiedToDoItemExpiredEvent), context.Message.Id);

            await Task.CompletedTask;
        }
    }
}