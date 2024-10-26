namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Queries.GetToDoItemsPaginated
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;

    public class GetToDoItemsPaginatedQueryValidator : AbstractValidator<GetToDoItemsPaginatedQuery>
    {
        public GetToDoItemsPaginatedQueryValidator()
        {
            this.RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            this.RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}