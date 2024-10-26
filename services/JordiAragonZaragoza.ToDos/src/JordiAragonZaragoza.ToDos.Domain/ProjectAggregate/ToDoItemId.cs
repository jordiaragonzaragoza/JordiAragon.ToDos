namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate
{
    using System;
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.ValueObjects;

    public sealed class ToDoItemId : BaseValueObject
    {
        private ToDoItemId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; init; }

        public static ToDoItemId Create(Guid id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            return new ToDoItemId(id);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}