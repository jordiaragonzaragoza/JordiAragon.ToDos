namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Requests
{
    using System;

    public record class GetToDoItemsPaginatedRequest(int PageNumber = 1, int PageSize = 10);
}