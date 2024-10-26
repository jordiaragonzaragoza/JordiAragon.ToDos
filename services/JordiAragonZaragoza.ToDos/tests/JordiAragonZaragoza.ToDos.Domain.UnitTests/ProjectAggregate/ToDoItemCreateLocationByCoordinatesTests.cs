namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Events;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Position;
    using Xunit;

    public class ToDoItemCreateLocationByCoordinatesTests
    {
        [Fact]
        public void RaisesToDoItemAddedEvent()
        {
            var toDoItem = ToDoItem.Create(
                ToDoItemId.Create(Guid.NewGuid()),
                ProjectId.Create(Guid.NewGuid()),
                "test name",
                "test description",
                Priority.None);

            var granadaCoordinates = Coordinates.Create(
                (Latitude)37.1773f,
                (Longitude)(-3.5985f));

            toDoItem.CreateLocationByCoordinates(granadaCoordinates);

            toDoItem.DomainEvents.Should()
                                .ContainSingle(x => x.GetType() == typeof(CoordinatesEstablishedToItemEvent))
                                .Which.As<CoordinatesEstablishedToItemEvent>().Item.Should().Be(toDoItem);
        }
    }
}