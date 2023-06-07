namespace JordiAragon.ToDos.Domain.ProjectAggregate.Events
{
    using System;
    using JordiAragon.SharedKernel.Domain.Events;

    // TODO: This will be used to notify the contributor and the admin.
    public record class ToDoItemProjectReasignedEvent : BaseDomainEvent
    {
        public ToDoItemProjectReasignedEvent(
            ToDoItem item,
            Guid projectId)
        {
            this.Item = item;
            this.ProjectId = projectId;
        }

        public Guid ProjectId { get; private init; }

        public ToDoItem Item { get; private init; }
    }
}