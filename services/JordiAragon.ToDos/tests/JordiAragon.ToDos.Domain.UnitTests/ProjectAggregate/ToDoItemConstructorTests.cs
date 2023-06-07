namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using Xunit;

    public class ToDoItemConstructorTests
    {
        [Fact]
        public void Should_Be_Equal_To_Passed_Parameters()
        {
            var id = ToDoItemId.Create(Guid.NewGuid());
            var projectId = ProjectId.Create(Guid.NewGuid());
            var title = "test name";
            var description = "test description";
            var priority = Priority.None;

            var toDoItem = ToDoItem.Create(id, projectId, title, description, priority);

            toDoItem.Id.Should().Be(id);
            toDoItem.ProjectId.Should().Be(projectId);
            toDoItem.Title.Should().Be(title);
            toDoItem.Description.Should().Be(description);
            toDoItem.Priority.Should().Be(priority);
        }

        [Fact]
        public void Should_Be_A_Valid_Title()
        {
            var id = ToDoItemId.Create(Guid.NewGuid());
            var projectId = ProjectId.Create(Guid.NewGuid());
            string title = null;
            var description = "test description";
            var priority = Priority.None;

            Func<ToDoItem> toDoItem = () => ToDoItem.Create(id, projectId, title, description, priority);
            toDoItem.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'title')");
        }

        [Fact]
        public void Should_Be_A_Valid_ProjectId()
        {
            var id = ToDoItemId.Create(Guid.NewGuid());
            ProjectId projectId = null;
            string title = "ToDo Item";
            var description = "test description";
            var priority = Priority.None;

            Func<ToDoItem> toDoItem = () => ToDoItem.Create(id, projectId, title, description, priority);
            toDoItem.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'projectId')");
        }
    }
}