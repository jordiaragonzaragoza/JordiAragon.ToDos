namespace JordiAragon.MessageHub.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Domain.Events.Services;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class MessageHubDomainEventsDispatcher : BaseDomainEventsDispatcher
    {
        public MessageHubDomainEventsDispatcher(
            MessageHubContext context,
            IDomainEventsDispatcherService domainEventDispatcherService)
             : base(context, domainEventDispatcherService)
        {
        }
    }
}