namespace JordiAragon.ToDos.Application.Features.Contributor.Queries.GetContributorToDoItems
{
    using Ardalis.Specification;
    using JordiAragon.ToDos.Domain.ContributorAggregate;
    using JordiAragon.ToDos.Domain.ProjectAggregate;

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