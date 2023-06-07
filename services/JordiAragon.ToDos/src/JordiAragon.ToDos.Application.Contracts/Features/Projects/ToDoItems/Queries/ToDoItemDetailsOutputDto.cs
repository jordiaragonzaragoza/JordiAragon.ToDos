namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    using System;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries;

    public record class ToDoItemDetailsOutputDto(
        Guid Id,
        string Title,
        bool IsDone,
        string Description,
        PriorityOutputDto Priority,
        DateTime? ExpirationDateOnUtc,
        Guid ProjectId,
        Guid? ContributorId,
        LocationOutputDto Location);
}