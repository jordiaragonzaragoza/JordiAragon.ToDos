namespace JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries
{
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetContributorsPaginatedQuery(int PageNumber = 1, int PageSize = 10) : IQuery<PaginatedCollectionOutputDto<ContributorOutputDto>>;
}