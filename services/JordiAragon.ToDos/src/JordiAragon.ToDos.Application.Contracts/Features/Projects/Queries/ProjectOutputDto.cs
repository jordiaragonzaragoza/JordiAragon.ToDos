namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public record class ProjectOutputDto(Guid Id, string Name);
}