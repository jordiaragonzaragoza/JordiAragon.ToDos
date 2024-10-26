namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;

    public class ToDosReadRepository<T> : BaseReadRepository<T>
        where T : class
    {
        public ToDosReadRepository(ToDosContext dbContext)
            : base(dbContext)
        {
        }
    }
}
