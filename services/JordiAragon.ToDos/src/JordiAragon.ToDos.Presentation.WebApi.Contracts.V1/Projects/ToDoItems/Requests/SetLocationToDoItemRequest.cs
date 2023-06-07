namespace JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Projects.ToDoItems.Requests
{
    using System;

    public record class SetLocationToDoItemRequest(float Latitude, float Longitude);
}