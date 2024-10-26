namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate.Specifications
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications;
    using Xunit;

    public class ProjectExtendedByIdSpecTests
    {
        [Fact]
        public void Should_Find_A_Project_With_Items_By_Given_Project_Id()
        {
            var guid = new Guid("6d0d6272-d38e-11ed-afa1-0242ac120002");
            var project1Id = ProjectId.Create(guid);

            var project1 = Project.Create(
                project1Id,
                "test name",
                Priority.None,
                Color.White);

            var toDoItem = project1.AddItem(ToDoItemId.Create(Guid.NewGuid()), "ToDo Item", null);

            var project2 = Project.Create(
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                Priority.None,
                Color.White);

            var projects = new List<Project>() { project1, project2 };

            var spec = new ProjectExtendedByIdSpec(project1Id);

            var evaluatedList = spec.Evaluate(projects);

            evaluatedList.Should()
                         .NotContain(p => p == project2)
                         .And
                         .ContainSingle(p => p == project1)
                         .Which.Items.Should().NotBeNull()
                         .And.Contain(toDoItem);
        }
    }
}