﻿namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Queries
{
    using System;
    using System.Collections.Generic;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetContributorToDoItemsQuery(Guid Id) : IQuery<IEnumerable<ToDoItemOutputDto>>;
}