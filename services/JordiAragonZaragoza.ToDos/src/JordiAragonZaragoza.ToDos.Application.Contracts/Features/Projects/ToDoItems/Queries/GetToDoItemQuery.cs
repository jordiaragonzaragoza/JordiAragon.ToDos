namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetToDoItemQuery(Guid ProjectId, Guid Id) : IQuery<ToDoItemOutputDto>;
}