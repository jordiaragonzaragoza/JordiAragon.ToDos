namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Position
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Latitude : BaseValueObject
    {
        private Latitude(float value)
        {
            Guard.Against.OutOfRange(value, nameof(value), -90, 90, "Latitude must be in range [-90; 90]");

            this.Value = value;
        }

        public float Value { get; init; }

        public static implicit operator float(Latitude latitude)
        {
            return latitude.Value;
        }

        public static explicit operator Latitude(float value)
        {
            return new Latitude(value);
        }

        public static Latitude FromScalar(float value)
        {
            return new Latitude(value);
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
