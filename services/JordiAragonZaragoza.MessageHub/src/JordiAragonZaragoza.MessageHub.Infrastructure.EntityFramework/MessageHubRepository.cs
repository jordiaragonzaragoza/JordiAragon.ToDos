namespace JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class MessageHubRepository<T> : BaseRepository<T>
        where T : class, IAggregateRoot
    {
        public MessageHubRepository(MessageHubContext dbContext)
            : base(dbContext)
        {
        }
    }
}
