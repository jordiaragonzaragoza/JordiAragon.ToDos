namespace JordiAragon.ToDos.Domain.ProjectAggregate.Events
{
    using JordiAragon.SharedKernel.Domain.Events;
    using JordiAragon.ToDos.Domain.ProjectAggregate;

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