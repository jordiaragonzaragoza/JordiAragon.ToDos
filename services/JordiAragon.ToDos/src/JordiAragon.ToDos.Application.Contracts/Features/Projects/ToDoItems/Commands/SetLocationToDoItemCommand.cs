namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class SetLocationToDoItemCommand : ICommand
    {
        public Guid ProjectId { get; set; }

        public Guid Id { get; set; }

        public float Latitude { get; init; }

        public float Longitude { get; init; }
    }
}