namespace JordiAragonZaragoza.MessageHub.Presentation.IntegrationMessages.AssemblyConfiguration
{
    using System;
    using global::MassTransit;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;

    public class MassTransitBusRegistrationConfigurator : IMassTransitBusRegistrationConfigurator
    {
        public Action<IBusRegistrationConfigurator> Configure { get; set; }
    }
}