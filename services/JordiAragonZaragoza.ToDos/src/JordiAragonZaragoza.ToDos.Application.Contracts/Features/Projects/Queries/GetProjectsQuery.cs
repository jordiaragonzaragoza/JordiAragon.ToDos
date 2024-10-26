namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries
{
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetProjectsQuery : IQuery<IEnumerable<ProjectOutputDto>>;
}