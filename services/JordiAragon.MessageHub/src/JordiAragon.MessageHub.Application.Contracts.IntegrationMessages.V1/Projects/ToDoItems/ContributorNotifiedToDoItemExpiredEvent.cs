namespace JordiAragon.MessageHub.Application.Contracts.IntegrationMessages.V1.Projects.ToDoItems
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.Interfaces;

    public record class ContributorNotifiedToDoItemExpiredEvent(
        Guid Id,
        string UserId,
        DateTime DateOccurredOnUtc,
        IDictionary<Guid, List<Guid>> ToDoItemsByContributor) : IIntegrationEvent
    {
        public DateTime? DatePublishedOnUtc { get; set; }
    }
}