namespace JordiAragon.MessageHub.AssemblyConfiguration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigureServices
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<SerilogConsoleOptions>(configuration.GetSection(SerilogConsoleOptions.Section));

            serviceCollection.AddHealthChecks();

            return serviceCollection;
        }
    }
}