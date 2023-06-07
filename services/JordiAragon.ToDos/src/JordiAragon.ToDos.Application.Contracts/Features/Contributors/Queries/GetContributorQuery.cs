namespace JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class GetContributorQuery(Guid Id) : IQuery<ContributorOutputDto>, ICacheRequest
    {
        public string CacheKey => $"{ContributorConstants.CachePrefix}_{this.Id}";

        public TimeSpan? AbsoluteExpirationInSeconds { get; }
    }
}