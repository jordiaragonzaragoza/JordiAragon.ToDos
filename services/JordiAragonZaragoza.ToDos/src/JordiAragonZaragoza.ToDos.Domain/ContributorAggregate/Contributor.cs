namespace JordiAragonZaragoza.ToDos.Domain.ContributorAggregate
{
    using System;
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.Entities;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class Contributor : BaseAuditableEntity<ContributorId>, IAggregateRoot
    {
        private Contributor(ContributorId id, string name)
            : base(id)
        {
            this.Name = Guard.Against.NullOrEmpty(name, nameof(name));
        }

        public string Name { get; private set; }

        public static Contributor Create(ContributorId id, string name)
        {
            return new Contributor(id, name);
        }

        public void UpdateName(string newName)
        {
            this.Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
    }
}