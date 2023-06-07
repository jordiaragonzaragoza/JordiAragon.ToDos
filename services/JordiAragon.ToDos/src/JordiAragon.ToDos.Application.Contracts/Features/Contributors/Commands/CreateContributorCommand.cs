namespace JordiAragon.ToDos.Application.Contracts.Features.Contributors.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class CreateContributorCommand(string Name) : ICommand<Guid>, IInvalidateCacheRequest
    {
        public string PrefixCacheKey => ContributorConstants.CachePrefix;
    }
}