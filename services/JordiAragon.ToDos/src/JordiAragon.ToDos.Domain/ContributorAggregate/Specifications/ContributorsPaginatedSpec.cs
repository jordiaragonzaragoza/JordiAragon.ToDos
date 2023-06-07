namespace JordiAragon.ToDos.Domain.ContributorAggregate.Specifications
{
    using Ardalis.Specification;

    public class ContributorsPaginatedSpec : Specification<Contributor>
    {
        public ContributorsPaginatedSpec(int skip, int take)
        {
            this.Query
               .Skip(skip)
               .Take(take)
               .OrderByDescending(x => x.CreationDateOnUtc);
        }
    }
}