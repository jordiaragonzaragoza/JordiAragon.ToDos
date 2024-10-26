namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    using System;

    public record class ToDoItemOutputDto(Guid Id, string Title, bool IsDone);
}