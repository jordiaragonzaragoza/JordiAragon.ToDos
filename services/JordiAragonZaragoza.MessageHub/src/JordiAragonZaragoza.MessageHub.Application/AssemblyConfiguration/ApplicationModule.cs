namespace JordiAragonZaragoza.MessageHub.Application.AssemblyConfiguration
{
    using System.Reflection;
    using JordiAragon.SharedKernel;

    public class ApplicationModule : AssemblyModule
    {
        protected override Assembly CurrentAssembly => ApplicationAssemblyReference.Assembly;
    }
}