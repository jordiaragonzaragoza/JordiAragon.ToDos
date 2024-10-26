namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class UpdateContributorCommand : ICommand, IInvalidateCacheRequest
    {
        public Guid Id { get; set; } // This set is required to be wired post mapping.

        public string Name { get; init; }

        public string PrefixCacheKey => ContributorConstants.CachePrefix;
    }
}