namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class ReasignToDoItemToProjectCommand(Guid ProjectId, Guid Id, Guid DestinatioProjectId) : ICommand;
}
