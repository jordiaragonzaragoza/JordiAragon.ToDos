namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetToDoItemDetailsQuery(Guid ProjectId, Guid Id) : IQuery<ToDoItemDetailsOutputDto>;
}