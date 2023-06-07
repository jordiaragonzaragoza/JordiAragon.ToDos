namespace JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1.Projects.ToDoItems
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.Interfaces;

    public record class NotifyContributorsExpiredToDoItemsCommand(
        Guid Id,
        string UserId,
        DateTime DateOccurredOnUtc,
        IDictionary<Guid, List<Guid>> ToDoItemsByContributor) : IIntegrationCommand
    {
        public DateTime? DatePublishedOnUtc { get; set; }
    }
}