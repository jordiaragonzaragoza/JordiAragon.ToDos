namespace JordiAragonZaragoza.ToDos.Application.Contracts.Interfaces
{
    using System.Collections.Generic;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public interface ICsvFileBuilderService
    {
        byte[] BuildTodoItemsFile(IEnumerable<ToDoItemOutputDto> records);
    }
}