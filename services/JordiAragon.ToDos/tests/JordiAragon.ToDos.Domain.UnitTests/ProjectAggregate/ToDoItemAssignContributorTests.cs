namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Events;
    using Xunit;

    public class ToDoItemAssignContributorTests
    {
        [Fact]
        public void Should_Be_Assing_A_Valid_ContributorId()
        {
            var id = ToDoItemId.Create(Guid.NewGuid());
            var projectId = ProjectId.Create(Guid.NewGuid());
            string title = "ToDo Item";
            var description = "test description";
            var priority = Priority.None;
            ContributorId contributorId = null;

            var toDoItem = ToDoItem.Create(id, projectId, title, description, priority);

            Action assingContributor = () => toDoItem.AssignContributor(contributorId);

            assingContributor.Should()
                             .Throw<ArgumentNullException>()
                             .WithMessage("Value cannot be null. (Parameter 'contributorId')");
        }

        [Fact]
        public void Should_Be_Raise_A_ContributorAddedToItemEvent()
        {
            var id = ToDoItemId.Create(Guid.NewGuid());
            var projectId = ProjectId.Create(Guid.NewGuid());
            string title = "ToDo Item";
            var description = "test description";
            var priority = Priority.None;
            var contributorId = ContributorId.Create(Guid.NewGuid());

            var toDoItem = ToDoItem.Create(id, projectId, title, description, priority);
            toDoItem.AssignContributor(contributorId);

            toDoItem.DomainEvents.Should()
                                 .ContainSingle(x => x.GetType() == typeof(ContributorAddedToItemEvent) &&
                                                ((ContributorAddedToItemEvent)x).Item == toDoItem &&
                                                ((ContributorAddedToItemEvent)x).ContributorId == contributorId)
                                 .Which.As<ContributorAddedToItemEvent>();
        }
    }
}