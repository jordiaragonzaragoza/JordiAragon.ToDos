namespace JordiAragon.ToDos.Domain.ContributorAggregate.Specifications
{
    using Ardalis.Specification;

    public class ContributorByNameSpec : Specification<Contributor>
    {
        public ContributorByNameSpec(string name)
        {
            this.Query
                .Where(project => project.Name == name);
        }
    }
}