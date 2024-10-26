namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands
{
    using System;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public record class DeleteContributorCommand(Guid Id) : ICommand, IInvalidateCacheRequest
    {
        public string PrefixCacheKey => ContributorConstants.CachePrefix;
    }
}