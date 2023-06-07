namespace JordiAragon.MessageHub.Presentation.IntegrationMessages.AssemblyConfiguration
{
    using System.Reflection;
    using Autofac;
    using JordiAragon.SharedKernel;

    public class IntegrationMessagesModule : AssemblyModule
    {
        protected override Assembly CurrentAssembly => IntegrationMessagesAssemblyReference.Assembly;
    }
}