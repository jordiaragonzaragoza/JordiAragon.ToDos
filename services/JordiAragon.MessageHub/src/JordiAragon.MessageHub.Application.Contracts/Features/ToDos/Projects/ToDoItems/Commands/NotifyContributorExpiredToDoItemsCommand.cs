namespace JordiAragon.MessageHub.Application.Contracts.Features.ToDos.Projects.ToDoItems.Commands
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class NotifyContributorExpiredToDoItemsCommand(IDictionary<Guid, List<Guid>> ToDoItemsByContributor) : ICommand;
}