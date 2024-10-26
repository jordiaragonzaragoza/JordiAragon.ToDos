namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using Xunit;

    public class ProjectAddItemTests
    {
        [Fact]
        public void AddsItemToItems()
        {
            var project = Project.Create(
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                Priority.None,
                Color.White);

            var toDoItem = project.AddItem(ToDoItemId.Create(Guid.NewGuid()), "ToDo Item", null);

            project.Items.Should()
                          .Contain(toDoItem)
                          .And
                          .HaveCount(1);
        }

        [Fact]
        public void RaisesToDoItemAddedEvent()
        {
            var project = Project.Create(
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                Priority.None,
                Color.White);

            var toDoItem = project.AddItem(ToDoItemId.Create(Guid.NewGuid()), "ToDo Item", null);

            project.DomainEvents.Should()
                                .ContainSingle(x => x.GetType() == typeof(ToDoItemAddedEvent))
                                .Which.As<ToDoItemAddedEvent>().Item.Should().Be(toDoItem);
        }
    }
}