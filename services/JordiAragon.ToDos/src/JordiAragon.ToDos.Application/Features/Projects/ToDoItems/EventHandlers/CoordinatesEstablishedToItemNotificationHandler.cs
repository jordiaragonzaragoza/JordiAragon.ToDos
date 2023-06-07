namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.EventHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.ToDos.Application.Contracts.Interfaces;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Events.Notifications;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Position;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Specifications;
    using Microsoft.Extensions.Logging;

    public class CoordinatesEstablishedToItemNotificationHandler : IDomainEventNotificationHandler<CoordinatesEstablishedToItemNotification>
    {
        private readonly ILogger<CoordinatesEstablishedToItemNotificationHandler> logger;
        private readonly IGeolocationService geolocationService;
        private readonly IRepository<Project> projectRepository;

        public CoordinatesEstablishedToItemNotificationHandler(
            ILogger<CoordinatesEstablishedToItemNotificationHandler> logger,
            IGeolocationService geolocationService,
            IRepository<Project> projectRepository)
        {
            this.logger = Guard.Against.Null(logger, nameof(logger));
            this.geolocationService = Guard.Against.Null(geolocationService, nameof(geolocationService));
            this.projectRepository = Guard.Against.Null(projectRepository, nameof(projectRepository));
        }

        // TODO: Change to Task<Result> Handle.
        public async Task Handle(CoordinatesEstablishedToItemNotification notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Handled Notification: {DomainEvent}", notification.GetType().Name);

            var existingProject = await this.projectRepository.FirstOrDefaultAsync(new ProjectWithItemsByIdSpec(ProjectId.Create(notification.ProjectId)), cancellationToken);
            if (existingProject is null)
            {
                throw new KeyNotFoundException($"{nameof(Project)}: {notification.ProjectId} not found.");
            }

            var existingToDoItem = existingProject.Items.FirstOrDefault(item => item.Id.Value == notification.ToDoItemId);
            if (existingToDoItem is null)
            {
                throw new KeyNotFoundException($"{nameof(ToDoItem)}: {notification.Id} not found.");
            }

            var geocode = await this.geolocationService.GetGeocodeAsync(existingToDoItem.Location.Coordinates.Latitude.Value, existingToDoItem.Location.Coordinates.Longitude.Value, cancellationToken);

            var location = Location.Create(
                Coordinates.Create(Latitude.FromScalar(geocode.Value.Latitude), Longitude.FromScalar(geocode.Value.Longitude)),
                geocode.Value.Address,
                geocode.Value.CountryCode,
                geocode.Value.RegionCode,
                geocode.Value.Locality,
                geocode.Value.PostalCode);

            existingToDoItem.SetLocation(location);

            await this.projectRepository.UpdateAsync(existingProject, cancellationToken);
        }
    }
}