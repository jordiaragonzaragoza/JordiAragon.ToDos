namespace JordiAragon.ToDos.Domain.ProjectAggregate.Specifications
{
    using System;
    using Ardalis.Specification;
    using JordiAragon.ToDos.Domain.ProjectAggregate;

    public class ProjectExtendedByIdSpec : SingleResultSpecification<Project>
    {
        public ProjectExtendedByIdSpec(
             ProjectId id)
        {
            this.Query
                .Where(project => project.Id == id)
                .Include(project => project.Items);
        }
    }
}