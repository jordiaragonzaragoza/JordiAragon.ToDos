namespace JordiAragonZaragoza.ToDos.Domain.AccountAggregate
{
    using Ardalis.GuardClauses;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Domain.Entities;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;

    public class Account : BaseAuditableEntity<AccountId>, IAggregateRoot
    {
        private Account(
            AccountId id,
            string firstname,
            string lastname,
            string email,
            string password)
            : base(id)
        {
            this.Firstname = Guard.Against.NullOrEmpty(firstname, nameof(firstname));
            this.Lastname = Guard.Against.NullOrEmpty(lastname, nameof(lastname));
            this.Email = Guard.Against.NullOrEmpty(email, nameof(email));
            this.Password = Guard.Against.NullOrEmpty(password, nameof(password)); // TODO: Add encryption.
        }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; } // TODO: Add encryption.

        public static Account Create(
            AccountId id,
            string firstname,
            string lastname,
            string email,
            string password)
        {
            return new Account(id, firstname, lastname, email, password);
        }

        public void UpdateName(string newName)
        {
            this.Firstname = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }

        public void ChangePassword(string password)
        {
            this.Password = Guard.Against.NullOrEmpty(password, nameof(password)); // TODO: Add encryption.
        }
    }
}