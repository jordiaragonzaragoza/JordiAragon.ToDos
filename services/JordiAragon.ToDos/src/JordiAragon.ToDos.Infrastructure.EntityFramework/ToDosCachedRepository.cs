namespace JordiAragon.ToDos.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;
    using Microsoft.Extensions.Logging;

    public class ToDosCachedRepository<T> : BaseCachedRepository<T>
        where T : class, IAggregateRoot
    {
        public ToDosCachedRepository(
            ToDosContext dbContext,
            ILogger<ToDosCachedRepository<T>> logger,
            ICacheService cacheService)
            : base(dbContext, logger, cacheService)
        {
        }
    }
}
