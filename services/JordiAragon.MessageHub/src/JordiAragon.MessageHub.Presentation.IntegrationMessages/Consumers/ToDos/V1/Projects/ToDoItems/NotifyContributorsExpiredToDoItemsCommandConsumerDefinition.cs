namespace JordiAragon.MessageHub.Presentation.IntegrationMessages.Consumers.ToDos.V1.Projects.ToDoItems
{
    using MassTransit;
    using Microsoft.Extensions.Configuration;

    public class NotifyContributorsExpiredToDoItemsCommandConsumerDefinition : ConsumerDefinition<NotifyContributorsExpiredToDoItemsCommandConsumer>
    {
        public NotifyContributorsExpiredToDoItemsCommandConsumerDefinition(IConfiguration configuration)
        {
            this.EndpointName = configuration.GetRequiredSection("MessageBroker:Queues").GetValue<string>("NotificationsQueue");
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<NotifyContributorsExpiredToDoItemsCommandConsumer> consumerConfigurator)
        {
            endpointConfigurator.ConfigureConsumeTopology = false;

            base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);
        }
    }
}