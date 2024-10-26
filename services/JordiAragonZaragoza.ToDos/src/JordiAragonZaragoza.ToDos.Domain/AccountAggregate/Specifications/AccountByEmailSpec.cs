namespace JordiAragonZaragoza.ToDos.Domain.AccountAggregate.Specifications
{
    using Ardalis.Specification;

    public class AccountByEmailSpec : SingleResultSpecification<Account>
    {
        public AccountByEmailSpec(string email)
        {
            this.Query
                .Where(account => account.Email == email);
        }
    }
}