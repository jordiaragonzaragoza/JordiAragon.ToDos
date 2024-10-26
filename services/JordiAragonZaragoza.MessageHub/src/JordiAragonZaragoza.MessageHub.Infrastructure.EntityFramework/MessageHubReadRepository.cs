namespace JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class MessageHubReadRepository<T> : BaseReadRepository<T>
        where T : class
    {
        public MessageHubReadRepository(MessageHubContext dbContext)
            : base(dbContext)
        {
        }
    }
}
