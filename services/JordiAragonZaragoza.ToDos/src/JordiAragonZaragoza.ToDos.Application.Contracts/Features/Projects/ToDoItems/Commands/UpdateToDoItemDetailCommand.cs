namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class UpdateToDoItemDetailCommand : ICommand
    {
        public Guid Id { get; set; } // This set is required to be wired post mapping.

        public Guid ProjectId { get; set; } // This set is required to be wired post mapping.

        public string Title { get; init; }

        public bool IsDone { get; init; }

        public string Description { get; init; }

        public PriorityInputDto Priority { get; init; }

        public DateTime? ExpirationDateOnUtc { get; init; }
    }
}