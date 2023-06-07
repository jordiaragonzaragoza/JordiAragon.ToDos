namespace JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Lightness : BaseValueObject
    {
        private Lightness(double value)
        {
            Guard.Against.OutOfRange(value, nameof(value), 0, 100, "Lightness must be in range [0; 100]");
            this.Value = value;
        }

        public double Value { get; init; }

        public static implicit operator double(Lightness hue)
        {
            return hue.Value;
        }

        public static explicit operator Lightness(double value)
        {
            return new Lightness(value);
        }

        public static Lightness FromScalar(double value)
        {
            return new Lightness(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}