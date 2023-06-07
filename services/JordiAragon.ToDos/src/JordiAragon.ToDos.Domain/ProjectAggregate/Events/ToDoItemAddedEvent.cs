﻿namespace JordiAragon.ToDos.Domain.ProjectAggregate.Events
{
    using JordiAragon.SharedKernel.Domain.Events;
    using JordiAragon.ToDos.Domain.ProjectAggregate;

    public record class ToDoItemAddedEvent : BaseDomainEvent
    {
        public ToDoItemAddedEvent(
            ToDoItem item,
            Project project)
        {
            this.Item = item;
        }

        public ToDoItem Item { get; private init; }
    }
}
