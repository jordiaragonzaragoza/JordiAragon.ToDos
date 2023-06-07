namespace JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetContributorsQuery : IQuery<IEnumerable<ContributorOutputDto>>, ICacheRequest
    {
        public string CacheKey => ContributorConstants.CachePrefix;

        public TimeSpan? AbsoluteExpirationInSeconds { get; }
    }
}