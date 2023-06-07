namespace JordiAragon.ToDos.Infrastructure.EntityFramework.AssemblyConfiguration
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

            builder.RegisterGeneric(typeof(ToDosRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ToDosCachedRepository<>))
                .As(typeof(ICachedRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ToDosReadRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}