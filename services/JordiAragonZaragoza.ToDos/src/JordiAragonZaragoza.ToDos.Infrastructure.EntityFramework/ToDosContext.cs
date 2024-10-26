namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework.Interceptors;
    using JordiAragonZaragoza.ToDos.Domain.AccountAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class ToDosContext : BaseContext
    {
        public ToDosContext(
            DbContextOptions<ToDosContext> options,
            ILoggerFactory loggerFactory,
            IHostEnvironment hostEnvironment,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options, loggerFactory, hostEnvironment, auditableEntitySaveChangesInterceptor)
        {
        }

        public DbSet<Account> Accounts => this.Set<Account>();

        public DbSet<Contributor> Contributors => this.Set<Contributor>();

        public DbSet<Project> Projects => this.Set<Project>();

        public DbSet<ToDoItem> ToDoItems => this.Set<ToDoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureEntityFrameworkAssemblyReference.Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}