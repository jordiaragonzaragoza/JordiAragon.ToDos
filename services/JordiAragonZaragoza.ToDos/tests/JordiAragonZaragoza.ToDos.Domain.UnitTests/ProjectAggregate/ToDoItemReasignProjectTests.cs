namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using Xunit;

    public class ToDoItemReasignProjectTests
    {
        [Fact]
        public void Should_Be_Reasign_A_Valid_ProjectId()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            ProjectId projectId = null;

            Action reasignProject = () => toDoItem.ReasignProject(projectId);

            reasignProject.Should()
                             .Throw<ArgumentNullException>()
                             .WithMessage("Value cannot be null. (Parameter 'projectId')");
        }

        [Fact]
        public void Should_Be_Raise_A_ToDoItemProjectReasignedEvent()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            var projectId = ProjectId.Create(Guid.NewGuid());

            toDoItem.ReasignProject(projectId);

            toDoItem.DomainEvents.Should()
                                 .ContainSingle(x => x.GetType() == typeof(ToDoItemProjectReasignedEvent) &&
                                                ((ToDoItemProjectReasignedEvent)x).Item == toDoItem &&
                                                ((ToDoItemProjectReasignedEvent)x).ProjectId == projectId.Value)
                                 .Which.As<ToDoItemProjectReasignedEvent>();
        }
    }
}