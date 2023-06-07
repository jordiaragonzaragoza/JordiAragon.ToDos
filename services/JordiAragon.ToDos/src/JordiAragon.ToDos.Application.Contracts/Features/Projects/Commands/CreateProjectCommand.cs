namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class CreateProjectCommand(string Name) : ICommand<Guid>;
}