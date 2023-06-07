namespace JordiAragon.ToDos.Application.Contracts.Interfaces
{
    using System.Collections.Generic;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public interface ICsvFileBuilderService
    {
        byte[] BuildTodoItemsFile(IEnumerable<ToDoItemOutputDto> records);
    }
}