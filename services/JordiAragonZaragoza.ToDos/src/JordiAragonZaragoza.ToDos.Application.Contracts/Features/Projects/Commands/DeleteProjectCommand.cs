namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands
{
    using System;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class DeleteProjectCommand(Guid Id) : ICommand;
}