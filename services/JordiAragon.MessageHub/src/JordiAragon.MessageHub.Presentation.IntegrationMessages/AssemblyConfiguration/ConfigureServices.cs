namespace JordiAragon.MessageHub.Presentation.IntegrationMessages.AssemblyConfiguration
{
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using MassTransit;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigureServices
    {
        public static IServiceCollection AddIntegrationMessagesServices(this IServiceCollection serviceCollection)
        {
            var massTransitBusRegistrationConfigurator = new MassTransitBusRegistrationConfigurator();
            massTransitBusRegistrationConfigurator.Configure += (busRegistrationConfigurator) =>
            {
                busRegistrationConfigurator.AddConsumers(IntegrationMessagesAssemblyReference.Assembly);
            };

            serviceCollection.AddSingleton<IMassTransitBusRegistrationConfigurator>(massTransitBusRegistrationConfigurator);

            return serviceCollection;
        }
    }
}