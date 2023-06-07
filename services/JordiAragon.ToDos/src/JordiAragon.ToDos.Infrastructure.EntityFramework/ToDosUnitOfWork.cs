namespace JordiAragon.ToDos.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class ToDosUnitOfWork : BaseUnitOfWork
    {
        public ToDosUnitOfWork(
            ToDosContext context)
            : base(context)
        {
        }
    }
}