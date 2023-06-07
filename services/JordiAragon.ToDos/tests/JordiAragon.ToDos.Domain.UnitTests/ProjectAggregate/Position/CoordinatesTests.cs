namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate.Position
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Position;
    using Xunit;

    public class CoordinatesTests
    {
        [Fact]
        public void Should_Be_Equal_To_Passed_Parameters()
        {
            var coordinates = Coordinates.Create(
                (Latitude)37.1773f,
                (Longitude)(-3.5985f));

            coordinates.Latitude.Should().Be((Latitude)37.1773f);
            coordinates.Longitude.Should().Be((Longitude)(-3.5985f));
        }

        [Fact]
        public void Should_Be_Equal_To_Another_Coordinates_With_The_Same_Latitude_And_Longitude()
        {
            var positionOne = Coordinates.Create((Latitude)37.1773f, (Longitude)(-3.5985f));
            var positionTwo = Coordinates.Create((Latitude)37.1773f, (Longitude)(-3.5985f));
            positionOne.Should().Be(positionTwo);
        }

        [Fact]
        public void Should_Calculate_The_Straight_Distance_In_Kilometers_Between_Granada_And_Madrid()
        {
            var granadaCoordinates = Coordinates.Create(
                (Latitude)37.1773f,
                (Longitude)(-3.5985f));
            var madridCoordinates = Coordinates.Create(
                (Latitude)40.4168f,
                (Longitude)(-3.70379f));
            var distance = granadaCoordinates.StraightDistanceInKilometersTo(madridCoordinates);
            distance.Should().Be(360.75702f);
        }
    }
}