namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetToDoItemsQuery(Guid ProjectId) : IQuery<IEnumerable<ToDoItemOutputDto>>;
}