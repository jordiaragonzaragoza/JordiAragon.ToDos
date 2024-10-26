namespace JordiAragonZaragoza.MessageHub.Application.AssemblyConfiguration
{
    using JordiAragon.SharedKernel.Application.Behaviours;
    using MediatR;
    using MediatR.NotificationPublishers;
    using MediatR.Pipeline;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(ApplicationAssemblyReference.Assembly);

            serviceCollection.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(ApplicationAssemblyReference.Assembly);
                configuration.NotificationPublisher = new TaskWhenAllPublisher();
            });

            // Register pipeline behaviors for validations and other stuff.
            serviceCollection.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggerBehaviour<>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehaviour<,>));
            ////serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>)); // TODO: Complete authorization.
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(InvalidateCachingBehavior<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainEventsDispatcherBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return serviceCollection;
        }
    }
}