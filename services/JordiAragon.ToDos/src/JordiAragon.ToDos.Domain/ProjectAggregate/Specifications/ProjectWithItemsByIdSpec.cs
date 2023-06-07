namespace JordiAragon.ToDos.Domain.ProjectAggregate.Specifications
{
    using System;
    using Ardalis.Specification;
    using JordiAragon.ToDos.Domain.ProjectAggregate;

    public class ProjectWithItemsByIdSpec : SingleResultSpecification<Project>
    {
        public ProjectWithItemsByIdSpec(ProjectId id)
        {
            this.Query
                .Where(project => project.Id == id)
                .Include(project => project.Items);
        }
    }
}