namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries
{
    using System;
    using System.Collections.Generic;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public record class ProjectDetailsOutputDto(
        Guid Id,
        string Name,
        PriorityOutputDto Priority,
        ColorOutputDto Color,
        IEnumerable<ToDoItemOutputDto> Items);
}