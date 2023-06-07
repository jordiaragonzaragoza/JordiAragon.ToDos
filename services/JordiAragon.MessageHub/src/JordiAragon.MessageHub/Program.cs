namespace JordiAragon.MessageHub
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using JordiAragon.MessageHub.Application.AssemblyConfiguration;
    using JordiAragon.MessageHub.Application.Contracts.AssemblyConfiguration;
    using JordiAragon.MessageHub.AssemblyConfiguration;
    using JordiAragon.MessageHub.Domain.AssemblyConfiguration;
    using JordiAragon.MessageHub.Infrastructure.AssemblyConfiguration;
    using JordiAragon.MessageHub.Infrastructure.EntityFramework.AssemblyConfiguration;
    using JordiAragon.MessageHub.Presentation.IntegrationMessages.AssemblyConfiguration;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using SharedKernelApplicationModule = JordiAragon.SharedKernel.Application.AssemblyConfiguration.ApplicationModule;
    using SharedKernelDomainModule = JordiAragon.SharedKernel.Domain.AssemblyConfiguration.DomainModule;
    using SharedKernelEntityFrameworkModule = JordiAragon.SharedKernel.Infrastructure.EntityFramework.AssemblyConfiguration.EntityFrameworkModule;
    using SharedKernelInfrastructureModule = JordiAragon.SharedKernel.Infrastructure.AssemblyConfiguration.InfrastructureModule;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1118:Utility classes should not have public constructors", Justification = "Program class should not have a protected constructor or the static keyword because is used in WebApplicationFactory for functional and integration test.")]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddApplicationServices(configuration);
            builder.Services.AddWebApiServices(configuration);
            builder.Services.AddIntegrationMessagesServices();
            builder.Services.AddInfrastructureServices(configuration, builder.Environment.EnvironmentName == "Development");
            builder.Services.AddEntityFrameworkServices(configuration, builder.Environment.EnvironmentName == "Development");

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new IntegrationMessagesModule());
                containerBuilder.RegisterModule(new DomainModule());
                containerBuilder.RegisterModule(new SharedKernelDomainModule());
                containerBuilder.RegisterModule(new SharedKernelApplicationModule());
                containerBuilder.RegisterModule(new ApplicationModule());
                containerBuilder.RegisterModule(new ApplicationContractsModule());
                containerBuilder.RegisterModule(new SharedKernelInfrastructureModule());
                containerBuilder.RegisterModule(new InfrastructureModule());
                containerBuilder.RegisterModule(new SharedKernelEntityFrameworkModule());
                containerBuilder.RegisterModule(new EntityFrameworkModule());
            });

            builder.Host.AddHostBuilderConfigurations();

            var app = builder.Build();

            ConfigureWebApplication.AddWebApplicationConfigurations(app);

            app.Run();
        }
    }
}