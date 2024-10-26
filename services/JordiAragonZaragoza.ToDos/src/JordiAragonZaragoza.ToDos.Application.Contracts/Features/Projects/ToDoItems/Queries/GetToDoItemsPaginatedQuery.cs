namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetToDoItemsPaginatedQuery : IQuery<PaginatedCollectionOutputDto<ToDoItemOutputDto>>
    {
        public Guid ProjectId { get; set; } // This set is required to be wired post mapping.

        public int PageNumber { get; init; } = 1;

        public int PageSize { get; init; } = 10;
    }
}