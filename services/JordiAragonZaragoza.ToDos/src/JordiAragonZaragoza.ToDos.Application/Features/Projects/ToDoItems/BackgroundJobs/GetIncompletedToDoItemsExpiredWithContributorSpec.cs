namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.BackgroundJobs
{
    using System;
    using Ardalis.Specification;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;

    public class GetIncompletedToDoItemsExpiredWithContributorSpec : Specification<ToDoItem>
    {
        public GetIncompletedToDoItemsExpiredWithContributorSpec(DateTime currentDateTimeOnUtc)
        {
            this.Query
                .Where(toDoItem => !toDoItem.IsDone
                                    && toDoItem.ContributorId != null
                                    && toDoItem.ExpirationDateOnUtc < currentDateTimeOnUtc);
        }
    }
}