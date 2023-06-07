namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate.Position
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate.Position;
    using Xunit;

    public class LongitudeTests
    {
        [Theory]
        [InlineData(-181)]
        [InlineData(181)]
        public void Should_Be_In_A_Valid_Range(int value)
        {
            Action longitude = () => Longitude.FromScalar(value);
            longitude.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Longitude must be in range [-180; 180] (Parameter 'value')");
        }
    }
}
