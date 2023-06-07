namespace JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Domain.ValueObjects;
    using JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels.Rules;

    public class Color : BaseValueObject
    {
        // Required by EF
        private Color()
        {
        }

        private Color(Intensity red, Intensity green, Intensity blue)
        {
            this.R = red;
            this.G = green;
            this.B = blue;
        }

        public static Color White => new(Intensity.FromScalar(0), Intensity.FromScalar(0), Intensity.FromScalar(0));

        public static Color Red => new(Intensity.FromScalar(255), Intensity.FromScalar(87), Intensity.FromScalar(51));

        public static Color Orange => new(Intensity.FromScalar(255), Intensity.FromScalar(195), Intensity.FromScalar(0));

        public static Color Yellow => new(Intensity.FromScalar(255), Intensity.FromScalar(255), Intensity.FromScalar(102));

        public static Color Green => new(Intensity.FromScalar(204), Intensity.FromScalar(255), Intensity.FromScalar(153));

        public static Color Blue => new(Intensity.FromScalar(102), Intensity.FromScalar(102), Intensity.FromScalar(255));

        public static Color Purple => new(Intensity.FromScalar(153), Intensity.FromScalar(102), Intensity.FromScalar(204));

        public static Color Grey => new(Intensity.FromScalar(153), Intensity.FromScalar(153), Intensity.FromScalar(153));

        public static Color Black => new(Intensity.FromScalar(255), Intensity.FromScalar(255), Intensity.FromScalar(255));

        public Intensity R { get; init; }

        public Intensity G { get; init; }

        public Intensity B { get; init; }

        protected static IEnumerable<Color> SupportedColors
        {
            get
            {
                yield return White;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Grey;
                yield return Black;
            }
        }

        public static Color FromRgb(Intensity red, Intensity green, Intensity blue)
        {
            var color = new Color(red, green, blue);

            Color.CheckRule(new OnlySupportedColorsCanBeCreatedRule(color, SupportedColors));

            return color;
        }

        public static Color FromHsl(Hue hue, Saturation saturation, Lightness lighness)
        {
            byte r;
            byte b;
            byte g;

            if (saturation == 0)
            {
                r = g = b = (byte)(lighness * 255);
            }
            else
            {
                double v1, v2;
                double hueTemp = hue / 360;
                double saturationTemp = saturation / 100;
                double lighnessTemp = lighness / 100;
                v2 = (lighnessTemp < 0.5) ? (lighnessTemp * (1 + saturationTemp)) : (lighnessTemp + saturationTemp - (lighnessTemp * saturationTemp));
                v1 = (2 * lighnessTemp) - v2;

                r = (byte)(255 * HueToRGB(v1, v2, hueTemp + (1.0f / 3)));
                g = (byte)(255 * HueToRGB(v1, v2, hueTemp));
                b = (byte)(255 * HueToRGB(v1, v2, hueTemp - (1.0f / 3)));
            }

            var color = new Color(Intensity.FromScalar(r), Intensity.FromScalar(g), Intensity.FromScalar(b));

            Color.CheckRule(new OnlySupportedColorsCanBeCreatedRule(color, SupportedColors));

            return color;
        }

        public static Color FromHex(string hexColor)
        {
            hexColor = hexColor.Replace("#", string.Empty).Trim();

            if (hexColor.Length != 6)
            {
                throw new ArgumentException("The hexadecimal color value must be 6 characters long.");
            }

            byte r = Convert.ToByte(hexColor.Substring(0, 2), 16);
            byte g = Convert.ToByte(hexColor.Substring(2, 2), 16);
            byte b = Convert.ToByte(hexColor.Substring(4, 2), 16);

            var color = Color.FromRgb(Intensity.FromScalar(r), Intensity.FromScalar(g), Intensity.FromScalar(b));

            Color.CheckRule(new OnlySupportedColorsCanBeCreatedRule(color, SupportedColors));

            return color;
        }

        public override string ToString()
        {
            return $"Color R: {this.R.Value} G: {this.G.Value} B: {this.B.Value}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.R;
            yield return this.G;
            yield return this.B;
        }

        private static double HueToRGB(double v1, double v2, double vH)
        {
            if (vH < 0)
            {
                vH += 1;
            }

            if (vH > 1)
            {
                vH -= 1;
            }

            if ((6 * vH) < 1)
            {
                return v1 + ((v2 - v1) * 6 * vH);
            }

            if ((2 * vH) < 1)
            {
                return v2;
            }

            if ((3 * vH) < 2)
            {
                return v1 + ((v2 - v1) * ((2.0f / 3) - vH) * 6);
            }

            return v1;
        }
    }
}