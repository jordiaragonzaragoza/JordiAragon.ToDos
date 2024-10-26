namespace JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework.AssemblyConfiguration
{
    using System.Reflection;
    using Autofac;
    using JordiAragon.SharedKernel;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class EntityFrameworkModule : AssemblyModule
    {
        protected override Assembly CurrentAssembly => InfrastructureEntityFrameworkAssemblyReference.Assembly;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(MessageHubRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(MessageHubCachedRepository<>))
                .As(typeof(ICachedRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(MessageHubReadRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}