namespace JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.Projects.Requests
{
    using System;

    public record class GetProjectsPaginatedRequest(int PageNumber = 1, int PageSize = 10);
}