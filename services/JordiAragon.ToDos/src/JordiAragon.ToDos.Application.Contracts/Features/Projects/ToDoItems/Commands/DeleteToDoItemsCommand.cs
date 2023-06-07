namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    ////[Authorize(Roles = "Administrator")]
    ////[Authorize(Policy = "CanPurge")]
    // TODO: Add autorization policy.
    public record class DeleteToDoItemsCommand(Guid ProjectId) : ICommand;
}