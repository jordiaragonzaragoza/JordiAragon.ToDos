namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications
{
    using System;
    using Ardalis.Specification;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

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