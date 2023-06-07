namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate.ColorModels
{
    using System;
    using FluentAssertions;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using Xunit;

    public class LightnessTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void Should_Be_In_A_Valid_Range(double value)
        {
            Action lightness = () => Lightness.FromScalar(value);
            lightness.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Lightness must be in range [0; 100] (Parameter 'value')");
        }

        [Fact]
        public void Should_Perform_Implicit_Conversion()
        {
            double lightness = Lightness.FromScalar(100);

            lightness.Should().Be(100);
        }

        [Fact]
        public void Should_Perform_Explicit_Conversion()
        {
            Lightness hue = (Lightness)100;

            hue.Should().Be(Lightness.FromScalar(100));
        }
    }
}