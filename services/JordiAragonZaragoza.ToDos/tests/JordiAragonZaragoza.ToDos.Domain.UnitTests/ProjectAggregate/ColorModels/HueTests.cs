namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate.ColorModels
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;
    using Xunit;

    public class HueTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(361)]
        public void Should_Be_In_A_Valid_Range(double value)
        {
            Action hue = () => Hue.FromScalar(value);
            hue.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Hue must be in range [0; 360] (Parameter 'value')");
        }

        [Fact]
        public void Should_Perform_Implicit_Conversion()
        {
            double hue = Hue.FromScalar(100);

            hue.Should().Be(100);
        }

        [Fact]
        public void Should_Perform_Explicit_Conversion()
        {
            Hue hue = (Hue)100;

            hue.Should().Be(Hue.FromScalar(100));
        }
    }
}