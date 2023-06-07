namespace JordiAragon.MessageHub.Infrastructure.AssemblyConfiguration
{
    using System.Reflection;
    using Autofac;
    using JordiAragon.SharedKernel;

    public class InfrastructureModule : AssemblyModule
    {
        protected override Assembly CurrentAssembly => InfrastructureAssemblyReference.Assembly;
    }
}