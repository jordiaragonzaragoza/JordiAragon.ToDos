﻿namespace JordiAragon.ToDos.Application.Contracts.Features.Projects.Queries
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetProjectDetailsQuery(Guid Id) : IQuery<ProjectDetailsOutputDto>;
}