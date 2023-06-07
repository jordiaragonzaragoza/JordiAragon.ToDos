namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Events;
    using Xunit;

    public class ProjectRemoveItemTests
    {
        [Fact]
        public void RemoveItemToItems()
        {
            var project = Project.Create(
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                Priority.None,
                Color.White);

            var itemToRemove = project.AddItem(ToDoItemId.Create(Guid.NewGuid()), "ToDo Item", null);
            project.RemoveItem(itemToRemove.Id);

            project.Items.Should().NotContain(itemToRemove);
        }

        [Fact]
        public void ThrowsExceptionGivenNullItem()
        {
            var project = Project.Create(
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                Priority.None,
                Color.White);

            Action action = () => project.RemoveItem(null);

            action.Should()
                  .Throw<ArgumentNullException>()
                  .WithMessage("Value cannot be null. (Parameter 'itemToRemove')");
        }

        [Fact]
        public void RaisesToDoItemRemovedEvent()
        {
            var project = Project.Create(
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                Priority.None,
                Color.White);

            var itemToRemove = project.AddItem(ToDoItemId.Create(Guid.NewGuid()), "ToDo Item", null);
            project.RemoveItem(itemToRemove.Id);

            project.DomainEvents.Should()
                                .ContainSingle(x => x.GetType() == typeof(ToDoItemRemovedEvent))
                                .Which.As<ToDoItemRemovedEvent>().Item.Should().Be(itemToRemove);
        }
    }
}