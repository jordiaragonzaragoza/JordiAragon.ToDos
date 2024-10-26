namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using Xunit;

    public class ToDoItemMarkAsCompleteTests
    {
        [Fact]
        public void SetsIsDoneToTrue()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            toDoItem.MarkAsComplete();

            toDoItem.IsDone.Should().BeTrue();
        }

        [Fact]
        public void RaisesToDoItemCompletedEvent()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            toDoItem.MarkAsComplete();

            toDoItem.DomainEvents.Should()
                                .ContainSingle(x => x.GetType() == typeof(ToDoItemMakedAsCompletedEvent))
                                .Which.As<ToDoItemMakedAsCompletedEvent>().Item.Should().Be(toDoItem);
        }
    }
}