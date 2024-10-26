namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate
{
    using System;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.Entities;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Position;

    public class ToDoItem : BaseAuditableEntity<ToDoItemId>
    {
        private ToDoItem(
            ToDoItemId id,
            ProjectId projectId,
            string title,
            string description,
            Priority priority)
            : base(id)
        {
            this.ProjectId = Guard.Against.Null(projectId, nameof(projectId));
            this.Title = Guard.Against.NullOrEmpty(title, nameof(title));
            this.Description = description;
            this.Priority = priority;
        }

        public string Title { get; private set; }

        public bool IsDone { get; private set; }

        public string Description { get; private set; }

        public Priority Priority { get; private set; }

        public DateTime? ExpirationDateOnUtc { get; private set; }

        public Location Location { get; private set; }

        public ProjectId ProjectId { get; private set; }

        public ContributorId ContributorId { get; private set; }

        public static ToDoItem Create(
            ToDoItemId id,
            ProjectId projectId,
            string title,
            string description,
            Priority priority)
        {
            return new ToDoItem(id, projectId, title, description, priority);
        }

        public void UpdateTitle(string newTitle)
        {
            this.Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
        }

        public void MarkAsComplete()
        {
            if (!this.IsDone)
            {
                this.IsDone = true;

                var @event = new ToDoItemMakedAsCompletedEvent(this);

                this.RegisterDomainEvent(@event);
            }
        }

        public void MarkAsIncomplete()
        {
            if (this.IsDone)
            {
                this.IsDone = false;

                var @event = new ToDoItemMakedAsIncompleteEvent(this);

                this.RegisterDomainEvent(@event);
            }
        }

        public void AssignContributor(ContributorId contributorId)
        {
            this.ContributorId = Guard.Against.Null(contributorId, nameof(contributorId));

            var contributorAddedToItem = new ContributorAddedToItemEvent(this, contributorId);
            this.RegisterDomainEvent(contributorAddedToItem);
        }

        public void RemoveContributor()
        {
            this.ContributorId = null;
        }

        public void ReasignProject(ProjectId projectId)
        {
            this.ProjectId = Guard.Against.Null(projectId, nameof(projectId));

            var @event = new ToDoItemProjectReasignedEvent(this, projectId.Value);
            this.RegisterDomainEvent(@event);
        }

        public void SetPriority(Priority newPriorityLevel)
        {
            this.Priority = newPriorityLevel;
        }

        public void ChangeDescription(string newDescription)
        {
            this.Description = newDescription;
        }

        public void SetExpirationDate(DateTime? expirationDateOnUtc)
        {
            this.ExpirationDateOnUtc = expirationDateOnUtc;
        }

        public void CreateLocationByCoordinates(Coordinates coordinates)
        {
            this.Location = Location.CreateByCoordinates(coordinates);

            var @event = new CoordinatesEstablishedToItemEvent(this);
            this.RegisterDomainEvent(@event);
        }

        public void SetLocation(Location location)
        {
            this.Location = location;
        }

        public override string ToString()
        {
            string status = this.IsDone ? "Done!" : "Not done.";
            return $"{this.Id}: Status: {status} - {this.Title} - {this.Description}";
        }
    }
}