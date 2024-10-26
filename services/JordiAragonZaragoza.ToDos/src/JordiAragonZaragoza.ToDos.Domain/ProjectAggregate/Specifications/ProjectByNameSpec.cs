namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications
{
    using Ardalis.Specification;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public class ProjectByNameSpec : Specification<Project>
    {
        public ProjectByNameSpec(string name)
        {
            this.Query
                .Where(project => project.Name == name);
        }
    }
}