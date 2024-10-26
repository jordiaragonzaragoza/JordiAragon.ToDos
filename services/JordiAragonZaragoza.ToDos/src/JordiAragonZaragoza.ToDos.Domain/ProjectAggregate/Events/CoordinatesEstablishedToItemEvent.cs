namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events
{
    using JordiAragon.SharedKernel.Domain.Events;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public record class CoordinatesEstablishedToItemEvent : BaseDomainEvent
    {
        public CoordinatesEstablishedToItemEvent(
            ToDoItem item)
        {
            this.Item = item;
        }

        public ToDoItem Item { get; private init; }
    }
}