namespace JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Contributors.Requests
{
    public record class GetContributorsPaginatedRequest(int PageNumber = 1, int PageSize = 10);
}