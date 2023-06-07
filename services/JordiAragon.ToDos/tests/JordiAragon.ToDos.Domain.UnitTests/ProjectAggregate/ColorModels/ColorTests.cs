namespace JordiAragon.ToDos.Domain.UnitTests.ProjectAggregate.ColorModels
{
    using System;
    using FluentAssertions;
    using JordiAragon.SharedKernel.Domain.Exceptions;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels;
    using Xunit;

    public class ColorTests
    {
        [Fact]
        public void Should_Return_Correct_Conversion_From_Hex_Code()
        {
            var code = "#FF5733";

            var color = Color.FromHex(code);

            color.R.Should().Be(Intensity.FromScalar(255));
            color.G.Should().Be(Intensity.FromScalar(87));
            color.B.Should().Be(Intensity.FromScalar(51));
        }

        [Fact]
        public void Should_Return_Correct_Conversion_From_HSL()
        {
            var hue = Hue.FromScalar(0);
            var saturation = Saturation.FromScalar(0);
            var lightness = Lightness.FromScalar(0);

            var color = Color.FromHsl(hue, saturation, lightness);

            color.R.Should().Be(Intensity.FromScalar(0));
            color.G.Should().Be(Intensity.FromScalar(0));
            color.B.Should().Be(Intensity.FromScalar(0));
        }

        [Fact]
        public void Should_Return_Correct_Color_From_RGB()
        {
            var red = Intensity.FromScalar(102);
            var green = Intensity.FromScalar(102);
            var blue = Intensity.FromScalar(255);

            var color = Color.FromRgb(red, green, blue);

            color.Should().Be(Color.Blue);
        }

        [Fact]
        public void Should_Be_A_Valid_Color()
        {
            var red = Intensity.FromScalar(255);
            var green = Intensity.FromScalar(0);
            var blue = Intensity.FromScalar(0);

            Action color = () => Color.FromRgb(red, green, blue);
            color.Should()
                .Throw<BusinessRuleValidationException>()
                .WithMessage("Only supported colors can be created:\nColor R: 0 G: 0 B: 0,\nColor R: 255 G: 87 B: 51,\nColor R: 255 G: 195 B: 0,\nColor R: 255 G: 255 B: 102,\nColor R: 204 G: 255 B: 153,\nColor R: 102 G: 102 B: 255,\nColor R: 153 G: 102 B: 204,\nColor R: 153 G: 153 B: 153,\nColor R: 255 G: 255 B: 255");
        }
    }
}