namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Saturation : BaseValueObject
    {
        private Saturation(double value)
        {
            Guard.Against.OutOfRange(value, nameof(value), 0, 100, "Saturation must be in range [0; 100]");
            this.Value = value;
        }

        public double Value { get; init; }

        public static implicit operator double(Saturation hue)
        {
            return hue.Value;
        }

        public static explicit operator Saturation(double value)
        {
            return new Saturation(value);
        }

        public static Saturation FromScalar(double value)
        {
            return new Saturation(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}