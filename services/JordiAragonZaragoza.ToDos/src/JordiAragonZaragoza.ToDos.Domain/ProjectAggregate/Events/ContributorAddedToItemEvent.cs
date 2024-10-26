namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events
{
    using JordiAragon.SharedKernel.Domain.Events;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public record class ContributorAddedToItemEvent : BaseDomainEvent
    {
        public ContributorAddedToItemEvent(
            ToDoItem item,
            ContributorId contributorId)
        {
            this.Item = item;
            this.ContributorId = contributorId;
        }

        public ContributorId ContributorId { get; private init; }

        public ToDoItem Item { get; private init; }
    }
}