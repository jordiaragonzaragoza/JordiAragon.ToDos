namespace JordiAragon.ToDos.Domain.ProjectAggregate.ColorModels
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public class Intensity : BaseValueObject
    {
        private Intensity(int value)
        {
            Guard.Against.OutOfRange(value, nameof(value), 0, 255, "Intensity must be in range [0; 255]");
            this.Value = value;
        }

        public int Value { get; init; }

        public static implicit operator int(Intensity intensity)
        {
            return intensity.Value;
        }

        public static explicit operator Intensity(int value)
        {
            return new Intensity(value);
        }

        public static Intensity FromScalar(int value)
        {
            return new Intensity(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}