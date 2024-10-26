namespace JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class MessageHubUnitOfWork : BaseUnitOfWork
    {
        public MessageHubUnitOfWork(
            MessageHubContext context)
            : base(context)
        {
        }
    }
}