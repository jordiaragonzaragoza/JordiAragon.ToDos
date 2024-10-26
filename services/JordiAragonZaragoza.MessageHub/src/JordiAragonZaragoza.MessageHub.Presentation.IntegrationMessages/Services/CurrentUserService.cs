namespace JordiAragonZaragoza.MessageHub.Presentation.IntegrationMessages.Services
{
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Contracts.DependencyInjection;

    public class CurrentUserService : ICurrentUserService, IScopedDependency
    {
        public string UserId { get; set; } // TODO: Try to get from ConsumeContext.

        public bool IsAuthenticated => !string.IsNullOrEmpty(this.UserId);
    }
}