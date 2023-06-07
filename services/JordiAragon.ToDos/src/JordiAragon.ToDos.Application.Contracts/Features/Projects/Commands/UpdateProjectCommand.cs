namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands
{
    using System;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class UpdateProjectCommand : ICommand
    {
        public Guid Id { get; set; } // This set is required to be wired post mapping.

        public string Name { get; init; }
    }
}