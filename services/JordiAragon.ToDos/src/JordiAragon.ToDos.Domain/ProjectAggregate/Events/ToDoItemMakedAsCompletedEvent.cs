namespace JordiAragon.ToDos.Domain.ProjectAggregate.Events
{
    using System;
    using JordiAragon.SharedKernel.Domain.Events;
    using JordiAragon.ToDos.Domain.ProjectAggregate;

    public record class ToDoItemMakedAsCompletedEvent : BaseDomainEvent
    {
        public ToDoItemMakedAsCompletedEvent(
            ToDoItem item)
        {
            this.Item = item;
        }

        public ToDoItem Item { get; }
    }
}