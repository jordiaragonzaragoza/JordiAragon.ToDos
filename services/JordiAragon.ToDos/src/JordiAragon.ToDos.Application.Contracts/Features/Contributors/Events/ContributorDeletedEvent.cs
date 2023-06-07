namespace JordiAragon.ToDos.Application.Contracts.Features.Contributors.Events
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Events;

    // This event will be used to remove contributor from item.
    public record class ContributorDeletedEvent : BaseApplicationEvent
    {
        public ContributorDeletedEvent(
            Guid contributorId)
        {
            this.ContributorId = contributorId;
        }

        public Guid ContributorId { get; init; }
    }
}