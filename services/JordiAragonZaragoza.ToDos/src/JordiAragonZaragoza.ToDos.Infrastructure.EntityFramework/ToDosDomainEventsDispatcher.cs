namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Domain.Events.Services;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class ToDosDomainEventsDispatcher : BaseDomainEventsDispatcher
    {
        public ToDosDomainEventsDispatcher(
            ToDosContext context,
            IDomainEventsDispatcherService domainEventDispatcherService)
             : base(context, domainEventDispatcherService)
        {
        }
    }
}