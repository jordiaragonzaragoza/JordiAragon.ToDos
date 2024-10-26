namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class CreateToDoItemCommand : ICommand<Guid>
    {
        public Guid ProjectId { get; set; } // This set is required to be wired post mapping.

        public string Title { get; init; }
    }
}