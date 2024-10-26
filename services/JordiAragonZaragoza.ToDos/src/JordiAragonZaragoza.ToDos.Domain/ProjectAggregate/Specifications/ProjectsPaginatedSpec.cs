namespace JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Specifications
{
    using System;
    using System.ComponentModel.Design;
    using Ardalis.Specification;

    public class ProjectsPaginatedSpec : Specification<Project>
    {
        public ProjectsPaginatedSpec(int skip, int take)
        {
            this.Query
               .Skip(skip)
               .Take(take)
               .OrderByDescending(x => x.CreationDateOnUtc);
        }
    }
}