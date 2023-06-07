namespace JordiAragon.ToDos.Domain.ContributorAggregate
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public sealed class ContributorId : BaseValueObject
    {
        private ContributorId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; init; }

        public static ContributorId Create(Guid id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            return new ContributorId(id);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}