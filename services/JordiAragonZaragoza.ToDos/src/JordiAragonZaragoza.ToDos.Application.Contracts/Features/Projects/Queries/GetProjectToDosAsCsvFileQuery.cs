namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetProjectToDosAsCsvFileQuery(Guid ProjectId) : IQuery<FileOutputDto>;
}