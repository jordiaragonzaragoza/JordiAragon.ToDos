namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    ////using CleanArchitecture.Application.Common.Security;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using MediatR;

    ////[Authorize(Roles = "Administrator")]
    ////[Authorize(Policy = "CanPurge")]
    // TODO: Add autorization policy.
    public record class DeleteProjectsCommand : ICommand;
}