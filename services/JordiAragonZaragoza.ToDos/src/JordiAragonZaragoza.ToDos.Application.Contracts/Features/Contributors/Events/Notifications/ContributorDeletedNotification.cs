namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Events
{
    using System;
    using System.Text.Json.Serialization;
    using JordiAragon.SharedKernel.Application.Contracts.Events;

    // This event will be used to notify the admin.
    public record class ContributorDeletedNotification : BaseApplicationEventNotification<ContributorDeletedEvent>
    {
        public ContributorDeletedNotification(
            ContributorDeletedEvent applicationEvent)
            : base(applicationEvent)
        {
            this.ContributorId = applicationEvent.ContributorId;
        }

        [JsonConstructor]
        public ContributorDeletedNotification(
            Guid contributorId)
        {
            this.ContributorId = contributorId;
        }

        [JsonPropertyName("ContributorId")]
        public Guid ContributorId { get; init; }
    }
}