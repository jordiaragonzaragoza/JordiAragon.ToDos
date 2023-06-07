namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries
{
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetProjectsPaginatedQuery(int PageNumber = 1, int PageSize = 10) : IQuery<PaginatedCollectionOutputDto<ProjectOutputDto>>;
}