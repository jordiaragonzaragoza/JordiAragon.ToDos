namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.RemoveContributorToDoItem
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class RemoveContributorToDoItemCommandValidator : AbstractValidator<RemoveContributorToDoItemCommand>
    {
        public RemoveContributorToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}