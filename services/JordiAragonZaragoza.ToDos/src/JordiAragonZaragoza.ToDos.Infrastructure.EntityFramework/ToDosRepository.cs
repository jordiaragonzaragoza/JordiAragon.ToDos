namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class ToDosRepository<T> : BaseRepository<T>
        where T : class, IAggregateRoot
    {
        public ToDosRepository(ToDosContext dbContext)
            : base(dbContext)
        {
        }
    }
}
