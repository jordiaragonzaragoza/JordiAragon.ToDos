namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses
{
    using System;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.Responses;

    public record class ToDoItemDetailsResponse(
        Guid Id,
        string Title,
        bool IsDone,
        string Description,
        PriorityResponse Priority,
        DateTime? ExpirationDateOnUtc,
        Guid ProjectId,
        Guid? ContributorId,
        LocationResponse Location);
}