namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItems
{
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public class GetToDoItemsQueryHandlerValidator : AbstractValidator<GetToDoItemsQuery>
    {
        public GetToDoItemsQueryHandlerValidator()
        {
            this.RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("ProjectId is required.");
        }
    }
}