namespace JordiAragonZaragoza.ToDos.Application.Features.Contributor.Queries.GetContributorToDoItems
{
    using Ardalis.Specification;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public class GetContributorToDoItemsSpec : Specification<ToDoItem>
    {
        public GetContributorToDoItemsSpec(ContributorId contributorId)
        {
            this.Query
                .Where(toDoItem => toDoItem.ContributorId == contributorId)
                .OrderByDescending(toDoItem => toDoItem.CreationDateOnUtc);
        }
    }
}