namespace JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Projects.Responses
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses;

    public record class ProjectDetailsResponse(
        Guid Id,
        string Name,
        PriorityResponse Priority,
        ColorResponse Color,
        IEnumerable<ToDoItemResponse> Items);
}