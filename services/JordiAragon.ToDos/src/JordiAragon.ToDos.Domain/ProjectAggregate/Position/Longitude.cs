namespace JordiAragon.ToDos.Domain.ProjectAggregate.Position
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Longitude : BaseValueObject
    {
        private Longitude(float value)
        {
            Guard.Against.OutOfRange(value, nameof(value), -180, 180, "Longitude must be in range [-180; 180]");

            this.Value = value;
        }

        public float Value { get; init; }

        public static implicit operator float(Longitude longitude)
        {
            return longitude.Value;
        }

        public static explicit operator Longitude(float value)
        {
            return new Longitude(value);
        }

        public static Longitude FromScalar(float value)
        {
            return new Longitude(value);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}
