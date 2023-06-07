namespace JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Hue : BaseValueObject
    {
        private Hue(double value)
        {
            Guard.Against.OutOfRange(value, nameof(value), 0, 360, "Hue must be in range [0; 360]");
            this.Value = value;
        }

        public double Value { get; init; }

        public static implicit operator double(Hue hue)
        {
            return hue.Value;
        }

        public static explicit operator Hue(int value)
        {
            return new Hue(value);
        }

        public static Hue FromScalar(double value)
        {
            return new Hue(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}