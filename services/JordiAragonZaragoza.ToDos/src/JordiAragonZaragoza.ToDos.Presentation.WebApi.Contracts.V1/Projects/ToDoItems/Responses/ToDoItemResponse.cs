namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Responses
{
    using System;

    public record class ToDoItemResponse(Guid Id, string Title, bool IsDone);
}