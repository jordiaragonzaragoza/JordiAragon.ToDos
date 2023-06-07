namespace JordiAragon.ToDos.Presentation.WebApi.AssemblyConfiguration
{
    using System.Reflection;
    using JordiAragon.SharedKernel;

    public class WebApiModule : AssemblyModule
    {
        protected override Assembly CurrentAssembly => WebApiAssemblyReference.Assembly;
    }
}