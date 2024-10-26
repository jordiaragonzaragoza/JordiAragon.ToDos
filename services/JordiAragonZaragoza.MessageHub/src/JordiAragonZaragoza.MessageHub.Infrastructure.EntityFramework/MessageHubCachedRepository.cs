namespace JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;
    using Microsoft.Extensions.Logging;

    public class MessageHubCachedRepository<T> : BaseCachedRepository<T>
        where T : class, IAggregateRoot
    {
        public MessageHubCachedRepository(
            MessageHubContext dbContext,
            ILogger<MessageHubCachedRepository<T>> logger,
            ICacheService cacheService)
            : base(dbContext, logger, cacheService)
        {
        }
    }
}
