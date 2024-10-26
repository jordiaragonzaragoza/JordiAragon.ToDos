namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications
{
    using System;
    using Ardalis.Specification;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

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