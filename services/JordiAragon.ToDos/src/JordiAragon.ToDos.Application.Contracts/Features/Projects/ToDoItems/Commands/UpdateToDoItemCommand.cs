namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class UpdateToDoItemCommand : ICommand
    {
        public Guid Id { get; set; } // This set is required to be wired post mapping.

        public string Title { get; init; }

        public bool IsDone { get; init; }

        public Guid ProjectId { get; set; } // This set is required to be wired post mapping.
    }
}