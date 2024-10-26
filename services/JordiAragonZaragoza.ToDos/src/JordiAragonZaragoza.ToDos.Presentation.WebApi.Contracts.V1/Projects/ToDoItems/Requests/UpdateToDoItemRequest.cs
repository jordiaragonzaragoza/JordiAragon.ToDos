namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Requests
{
    using System;

    public record class UpdateToDoItemRequest(string Title, bool IsDone);
}