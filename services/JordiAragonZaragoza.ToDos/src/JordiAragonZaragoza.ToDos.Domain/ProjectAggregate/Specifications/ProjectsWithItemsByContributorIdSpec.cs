namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications
{
    using System;
    using System.Linq;
    using Ardalis.Specification;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;

    public class ProjectsWithItemsByContributorIdSpec : Specification<Project>
    {
        public ProjectsWithItemsByContributorIdSpec(ContributorId contributorId)
        {
            this.Query
                .Where(project => project.Items.Any(item => item.ContributorId == contributorId))
                .Include(project => project.Items);
        }
    }
}