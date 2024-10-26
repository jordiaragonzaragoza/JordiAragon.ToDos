namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class AssignContributorToDoItemCommand(Guid ProjectId, Guid Id, Guid ContributorId) : ICommand;
}
