namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.BackgroundJobs
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1.Projects.ToDoItems;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using MassTransit;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Quartz;

    [DisallowConcurrentExecution]
    public class ExpirationToDoItemJob : IJob
    {
        private readonly IDateTime dateTime;
        private readonly IReadRepository<ToDoItem> todoRepository;
        private readonly IEventBus eventBus;
        private readonly ILogger<ExpirationToDoItemJob> logger;
        private readonly Uri endpointAddress;

        public ExpirationToDoItemJob(
            IDateTime dateTime,
            IReadRepository<ToDoItem> todoRepository,
            IConfiguration configuration,
            IEventBus eventBus,
            ILogger<ExpirationToDoItemJob> logger)
        {
            this.dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            this.todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            this.logger = logger;
            var notificationQueue = configuration is null ? throw new ArgumentNullException(nameof(configuration)) : configuration.GetRequiredSection("MessageBroker:Queues").GetValue<string>("NotificationsQueue");
            this.endpointAddress = new Uri("queue:" + notificationQueue);
        }

        // TODO: Review. Change to domain events?
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var toDosList = await this.todoRepository.ListAsync(new GetIncompletedToDoItemsExpiredWithContributorSpec(this.dateTime.UtcNow), context.CancellationToken);
                if (!toDosList.Any())
                {
                    return;
                }

                var toDoItemsByContributor = toDosList.GroupBy(i => i.ContributorId.Value, i => i.Id.Value).ToDictionary(g => g.Key, g => g.ToList());

                var command = new NotifyContributorsExpiredToDoItemsCommand(
                    Id: Guid.NewGuid(),
                    UserId: string.Empty,
                    DateOccurredOnUtc: this.dateTime.UtcNow,
                    ToDoItemsByContributor: toDoItemsByContributor);

                await this.eventBus.SendCommandAsync(command, this.endpointAddress, context.CancellationToken);
            }
            catch (Exception exception)
            {
                this.logger.LogError(
                   exception,
                   "Error sending: {@Name} Integration Command.",
                   nameof(NotifyContributorsExpiredToDoItemsCommand));
            }
        }
    }
}