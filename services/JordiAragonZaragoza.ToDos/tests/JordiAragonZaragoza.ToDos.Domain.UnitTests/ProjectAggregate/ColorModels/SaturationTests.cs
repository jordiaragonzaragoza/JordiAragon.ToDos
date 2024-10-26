namespace JordiAragonZaragoza.ToDos.Domain.UnitTests.ProjectAggregate.ColorModels
{
    using System;
    using FluentAssertions;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;
    using Xunit;

    public class SaturationTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void Should_Be_In_A_Valid_Range(double value)
        {
            Action saturation = () => Saturation.FromScalar(value);
            saturation.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Saturation must be in range [0; 100] (Parameter 'value')");
        }

        [Fact]
        public void Should_Perform_Implicit_Conversion()
        {
            double saturation = Saturation.FromScalar(100);

            saturation.Should().Be(100);
        }

        [Fact]
        public void Should_Perform_Explicit_Conversion()
        {
            Saturation hue = (Saturation)100;

            hue.Should().Be(Saturation.FromScalar(100));
        }
    }
}