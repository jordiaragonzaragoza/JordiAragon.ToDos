namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetProjectQuery(Guid Id) : IQuery<ProjectOutputDto>;
}