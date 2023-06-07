namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class RemoveContributorToDoItemCommand(Guid ProjectId, Guid Id) : ICommand;
}
