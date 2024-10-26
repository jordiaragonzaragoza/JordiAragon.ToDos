namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.AssignContributorToDoItem
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class AssignContributorToDoItemCommandValidator : AbstractValidator<AssignContributorToDoItemCommand>
    {
        public AssignContributorToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");

            this.RuleFor(x => x.ContributorId)
               .NotEmpty().WithMessage("ContributorId is required.");
        }
    }
}