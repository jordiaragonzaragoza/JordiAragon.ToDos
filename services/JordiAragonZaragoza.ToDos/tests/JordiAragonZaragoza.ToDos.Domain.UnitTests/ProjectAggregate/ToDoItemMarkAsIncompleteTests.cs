namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using Xunit;

    public class ToDoItemMarkAsIncompleteTests
    {
        [Fact]
        public void SetsIsDoneToFalse()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            toDoItem.MarkAsComplete();
            toDoItem.MarkAsIncomplete();

            toDoItem.IsDone.Should().BeFalse();
        }

        [Fact]
        public void RaisesToDoItemIncompletedEvent()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            toDoItem.MarkAsComplete();
            toDoItem.MarkAsIncomplete();

            toDoItem.DomainEvents.Should()
                                .ContainSingle(x => x.GetType() == typeof(ToDoItemMakedAsIncompleteEvent))
                                .Which.As<ToDoItemMakedAsIncompleteEvent>().Item.Should().Be(toDoItem);
        }
    }
}