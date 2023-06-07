namespace JordiAragon.ToDos.Domain.ProjectAggregate
{
    using System.Collections.Generic;
    using System.Linq;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Entities;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Events;
    using NotFoundException = JordiAragon.SharedKernel.Domain.Exceptions.NotFoundException;

    public class Project : BaseAuditableEntity<ProjectId>, IAggregateRoot
    {
        private readonly List<ToDoItem> items = new();

        private Project(
            ProjectId id,
            string name,
            Priority priority,
            Color color)
            : this(id, name, priority)
        {
            this.Color = color;
        }

        // Required by EF. Not allowed color value object.
        private Project(
            ProjectId id,
            string name,
            Priority priority)
            : base(id)
        {
            this.Name = Guard.Against.NullOrEmpty(name, nameof(name));
            this.Priority = priority;
        }

        public string Name { get; private set; }

        public Priority Priority { get; private set; }

        public Color Color { get; private set; }

        public IEnumerable<ToDoItem> Items => this.items.AsReadOnly();

        public static Project Create(
            ProjectId id,
            string name,
            Priority priority,
            Color color)
        {
            return new Project(id, name, priority, color);
        }

        public ToDoItem AddItem(ToDoItemId id, string title, string description)
        {
            var newToDoItem = ToDoItem.Create(
                id,
                projectId: this.Id,
                title: title,
                description: description,
                priority: Priority.None);

            this.items.Add(newToDoItem);

            var newItemAddedEvent = new ToDoItemAddedEvent(newToDoItem, this);
            this.RegisterDomainEvent(newItemAddedEvent);

            return newToDoItem;
        }

        public void RemoveItem(ToDoItemId itemToRemove)
        {
            Guard.Against.Null(itemToRemove, nameof(itemToRemove));

            var existingToDoItem = this.items.FirstOrDefault(item => item.Id == itemToRemove)
                                   ?? throw new NotFoundException(nameof(ToDoItem), itemToRemove.Value);

            this.items.Remove(existingToDoItem);

            var @event = new ToDoItemRemovedEvent(existingToDoItem);
            this.RegisterDomainEvent(@event);
        }

        public void RemoveAllItems()
        {
            this.items.Clear();
        }

        public void UpdateName(string newName)
        {
            this.Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }

        public void SetPriority(Priority priority)
        {
            this.Priority = priority;
        }

        public void SetColor(Color color)
        {
            this.Color = color;
        }
    }
}