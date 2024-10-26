namespace JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Commands
{
    ////using CleanArchitecture.Application.Common.Security;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    ////[Authorize(Roles = "Administrator")]
    ////[Authorize(Policy = "CanPurge")]
    // TODO: Add autorization policy.
    public record class DeleteContributorsCommand : ICommand, IInvalidateCacheRequest
    {
        public string PrefixCacheKey => ContributorConstants.CachePrefix;
    }
}