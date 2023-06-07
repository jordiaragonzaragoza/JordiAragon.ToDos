namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using Xunit;

    public class ProjectConstructorTests
    {
        [Fact]
        public void Should_Be_Equal_To_Passed_Parameters()
        {
            var id = ProjectId.Create(Guid.NewGuid());
            var name = "test name";
            var priority = Priority.None;
            var color = Color.White;

            var project = Project.Create(id, name, priority, color);

            project.Id.Should().Be(id);
            project.Name.Should().Be(name);
            project.Priority.Should().Be(priority);
            project.Color.Should().Be(color);
        }

        [Fact]
        public void Should_Be_A_Valid_Name()
        {
            var id = ProjectId.Create(Guid.NewGuid());
            string name = null;
            var priority = Priority.None;
            var color = Color.White;

            Func<Project> project = () => Project.Create(id, name, priority, color);
            project.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'name')");
        }
    }
}