namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public sealed class ProjectId : BaseValueObject
    {
        private ProjectId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; init; }

        public static ProjectId Create(Guid id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            return new ProjectId(id);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}