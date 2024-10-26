namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events.Notifications
{
    using System;
    using System.Text.Json.Serialization;
    using JordiAragon.SharedKernel.Domain.Events;

    public record class ToDoItemAddedNotification : BaseDomainEventNotification<ToDoItemAddedEvent>
    {
        public ToDoItemAddedNotification(ToDoItemAddedEvent domainEvent)
            : base(domainEvent)
        {
            this.ToDoItemId = domainEvent.Item.Id.Value;
            this.ProjectId = domainEvent.Item.ProjectId.Value;
        }

        [JsonConstructor]
        public ToDoItemAddedNotification(
            Guid toDoItemId,
            Guid projectId)
            : base()
        {
            this.ToDoItemId = toDoItemId;
            this.ProjectId = projectId;
        }

        [JsonPropertyName("ToDoItemId")]
        public Guid ToDoItemId { get; init; }

        [JsonPropertyName("ProjectId")]
        public Guid ProjectId { get; init; }
    }
}