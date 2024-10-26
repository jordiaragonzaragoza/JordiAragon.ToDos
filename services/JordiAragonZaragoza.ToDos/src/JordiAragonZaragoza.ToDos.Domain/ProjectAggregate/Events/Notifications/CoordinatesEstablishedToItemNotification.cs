namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events.Notifications
{
    using System;
    using System.Text.Json.Serialization;
    using JordiAragon.SharedKernel.Domain.Events;

    public record class CoordinatesEstablishedToItemNotification : BaseDomainEventNotification<CoordinatesEstablishedToItemEvent>
    {
        public CoordinatesEstablishedToItemNotification(
            CoordinatesEstablishedToItemEvent domainEvent)
            : base(domainEvent)
        {
            this.ToDoItemId = domainEvent.Item.Id.Value;
            this.ProjectId = domainEvent.Item.ProjectId.Value;
        }

        [JsonConstructor]
        public CoordinatesEstablishedToItemNotification(
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