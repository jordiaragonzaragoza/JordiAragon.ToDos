namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Position
{
    using System;
    using System.Collections.Generic;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Coordinates : BaseValueObject
    {
        private const float EarthRadiusInKilometers = 6378.0F;

        private Coordinates(Latitude latitude, Longitude longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        // Required by EF
        private Coordinates()
        {
        }

        public Latitude Latitude { get; init; }

        public Longitude Longitude { get; init; }

        public static Coordinates Create(Latitude latitude, Longitude longitude)
        {
            return new Coordinates(latitude, longitude);
        }

        public float StraightDistanceInKilometersTo(Coordinates position)
        {
            // Haversine formula
            var latitudeInRadian = ToRadian(position.Latitude - this.Latitude);
            var longitudeInRadian = ToRadian(position.Longitude - this.Longitude);
            var a = Math.Pow(Math.Sin(latitudeInRadian / 2), 2) +
                    (Math.Cos(ToRadian(latitudeInRadian)) *
                    Math.Cos(ToRadian(position.Latitude)) *
                    Math.Pow(Math.Sin(longitudeInRadian / 2), 2));
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusInKilometers * Convert.ToSingle(c);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Latitude;
            yield return this.Longitude;
        }

        private static float ToRadian(float value)
        {
            return Convert.ToSingle(Math.PI / 180) * value;
        }
    }
}
