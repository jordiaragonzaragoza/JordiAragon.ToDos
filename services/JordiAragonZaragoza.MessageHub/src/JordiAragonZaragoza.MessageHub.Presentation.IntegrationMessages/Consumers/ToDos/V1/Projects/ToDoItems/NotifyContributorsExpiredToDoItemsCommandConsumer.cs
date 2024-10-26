namespace JordiAragonZaragoza.MessageHub.Presentation.IntegrationMessages.Consumers.ToDos.V1.Projects.ToDoItems
{
    using System;
    using System.Threading.Tasks;
    using JordiAragonZaragoza.MessageHub.Application.Contracts.Features.ToDos.Projects.ToDoItems.Commands;
    using JordiAragonZaragoza.MessageHub.Application.Contracts.IntegrationMessages.V1.Projects.ToDoItems;
    using JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.Interfaces;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1.Projects.ToDoItems;
    using MassTransit;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class NotifyContributorsExpiredToDoItemsCommandConsumer : ICommandConsumer<NotifyContributorsExpiredToDoItemsCommand>
    {
        private readonly ILogger<NotifyContributorsExpiredToDoItemsCommandConsumer> logger;
        private readonly ICurrentUserService currentUserService;
        private readonly ISender sender;
        private readonly IDateTime dateTime;

        public NotifyContributorsExpiredToDoItemsCommandConsumer(
            ILogger<NotifyContributorsExpiredToDoItemsCommandConsumer> logger,
            ICurrentUserService currentUserService,
            ISender sender,
            IDateTime dateTime)
        {
            this.logger = logger;
            this.currentUserService = currentUserService;
            this.sender = sender;
            this.dateTime = dateTime;
        }

        public async Task Consume(ConsumeContext<NotifyContributorsExpiredToDoItemsCommand> context)
        {
            this.logger.LogInformation("Consume Command {Command}: {Message}", nameof(NotifyContributorsExpiredToDoItemsCommand), context.Message.Id);

            var command = new NotifyContributorExpiredToDoItemsCommand(context.Message.ToDoItemsByContributor);

            try
            {
                this.currentUserService.UserId = context.Message.UserId;
                var response = await this.sender.Send(command);

                if (response.IsSuccess)
                {
                    // Command response.
                    var @event = new ContributorNotifiedToDoItemExpiredEvent(
                        Id: Guid.NewGuid(),
                        UserId: string.Empty,
                        DateOccurredOnUtc: this.dateTime.UtcNow,
                        ToDoItemsByContributor: context.Message.ToDoItemsByContributor)
                    {
                        DatePublishedOnUtc = this.dateTime.UtcNow,
                    };

                    await context.Publish(@event, context.CancellationToken);
                }
                else
                {
                    // TODO: Add failure response.
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError(
                   exception,
                   "Error sending command: {Command}: {@Content}",
                   nameof(NotifyContributorExpiredToDoItemsCommand),
                   command);
            }
        }
    }
}