namespace JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework
{
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework;
    using JordiAragon.SharedKernel.Infrastructure.EntityFramework.Interceptors;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class MessageHubContext : BaseContext
    {
        public MessageHubContext(
            DbContextOptions<MessageHubContext> options,
            ILoggerFactory loggerFactory,
            IHostEnvironment hostEnvironment,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options, loggerFactory, hostEnvironment, auditableEntitySaveChangesInterceptor)
        {
        }

        // TODO: Add aggregates.
        ////public DbSet<Aggregate> Aggregates => this.Set<Aggregate>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureEntityFrameworkAssemblyReference.Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}