namespace JordiAragon.MessageHub.Infrastructure.AssemblyConfiguration
{
    using System;
    using EasyCaching.InMemory;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Infrastructure.Cache;
    using JordiAragon.SharedKernel.Infrastructure.Cache.EasyCaching;
    using JordiAragon.SharedKernel.Infrastructure.EventBus;
    using MassTransit;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration, bool isDevelopment)
        {
            serviceCollection.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.Section));
            serviceCollection.Configure<AzureServiceBusOptions>(configuration.GetSection(AzureServiceBusOptions.Section));

            serviceCollection.AddAutoMapper(InfrastructureAssemblyReference.Assembly);

            serviceCollection.AddMassTransit(busRegistrationConfigurator =>
            {
                busRegistrationConfigurator.SetKebabCaseEndpointNameFormatter();

                var massTransitBusRegistrationConfigurator = serviceCollection.BuildServiceProvider().GetRequiredService<IMassTransitBusRegistrationConfigurator>();
                massTransitBusRegistrationConfigurator.Configure?.Invoke(busRegistrationConfigurator);

                if (isDevelopment)
                {
                    busRegistrationConfigurator.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) =>
                    {
                        var options = busRegistrationContext.GetRequiredService<IOptionsSnapshot<RabbitMqOptions>>();
                        var rabbitMqOptions = options.Value;

                        rabbitMqBusFactoryConfigurator.Host(new Uri(rabbitMqOptions.Host), hostConfigurator =>
                        {
                            hostConfigurator.Username(rabbitMqOptions.Username);
                            hostConfigurator.Password(rabbitMqOptions.Password);
                        });

                        rabbitMqBusFactoryConfigurator.ConfigureEndpoints(busRegistrationContext);
                    });
                }
                else
                {
                    busRegistrationConfigurator.UsingAzureServiceBus((busRegistrationContext, serviceBusBusFactoryConfigurator) =>
                    {
                        var options = busRegistrationContext.GetRequiredService<IOptionsSnapshot<AzureServiceBusOptions>>();
                        serviceBusBusFactoryConfigurator.Host(options.Value.BuildConnectionString());
                    });
                }
            });

            var cacheOptions = new CacheOptions();
            configuration.Bind(CacheOptions.Section, cacheOptions);
            serviceCollection.AddSingleton(Options.Create(cacheOptions));

            var easyCachingInMemoryOptions = new EasyCachingInMemoryOptions();
            configuration.Bind(EasyCachingInMemoryOptions.Section, easyCachingInMemoryOptions);
            serviceCollection.AddSingleton(Options.Create(easyCachingInMemoryOptions));

            serviceCollection.AddEasyCaching(options =>
            {
                options.UseInMemory(
                    config =>
                    {
                        config.DBConfig = new InMemoryCachingOptions
                        {
                            // scan time, default value is 60s
                            ExpirationScanFrequency = easyCachingInMemoryOptions.DBConfigExpirationScanFrequency,

                            // total count of cache items, default value is 10000
                            SizeLimit = easyCachingInMemoryOptions.DBConfigSizeLimit,

                            // enable deep clone when reading object from cache or not, default value is true.
                            EnableReadDeepClone = easyCachingInMemoryOptions.DBConfigEnableReadDeepClone,

                            // enable deep clone when writing object to cache or not, default valuee is false.
                            EnableWriteDeepClone = easyCachingInMemoryOptions.DBConfigEnableWriteDeepClone,
                        };

                        // the max random second will be added to cache's expiration, default value is 120
                        config.MaxRdSecond = easyCachingInMemoryOptions.MaxRdSecond;

                        // whether enable logging, default is false
                        config.EnableLogging = easyCachingInMemoryOptions.EnableLogging;

                        // mutex key's alive time(ms), default is 5000
                        config.LockMs = easyCachingInMemoryOptions.LockMs;

                        // when mutex key alive, it will sleep some time, default is 300
                        config.SleepMs = easyCachingInMemoryOptions.SleepMs;
                    },
                    cacheOptions.DefaultName);
            });

            return serviceCollection;
        }
    }
}