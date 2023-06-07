namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate.Position
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Position;
    using Xunit;

    public class LatitudeTests
    {
        [Theory]
        [InlineData(-91)]
        [InlineData(91)]
        public void Should_Be_In_A_Valid_Range(int value)
        {
            Action latitude = () => Latitude.FromScalar(value);
            latitude.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"Latitude must be in range [-90; 90] (Parameter 'value')");
        }
    }
}