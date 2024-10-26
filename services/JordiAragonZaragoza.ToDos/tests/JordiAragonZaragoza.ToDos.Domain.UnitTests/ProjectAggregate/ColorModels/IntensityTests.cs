namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate.ColorModels
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;
    using Xunit;

    public class IntensityTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(256)]
        public void Should_Be_In_A_Valid_Range(int value)
        {
            Action intensity = () => Intensity.FromScalar(value);
            intensity.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Intensity must be in range [0; 255] (Parameter 'value')");
        }

        [Fact]
        public void Should_Perform_Implicit_Conversion()
        {
            int intensity = Intensity.FromScalar(100);

            intensity.Should().Be(100);
        }

        [Fact]
        public void Should_Perform_Explicit_Conversion()
        {
            Intensity intensity = (Intensity)100;

            intensity.Should().Be(Intensity.FromScalar(100));
        }
    }
}