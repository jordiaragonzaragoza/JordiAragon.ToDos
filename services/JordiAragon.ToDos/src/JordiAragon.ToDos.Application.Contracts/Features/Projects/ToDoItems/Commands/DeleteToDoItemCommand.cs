namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class DeleteToDoItemCommand(Guid ProjectId, Guid Id) : ICommand;
}