namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.CreateToDoItem
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class CreateToDoItemCommandValidator : AbstractValidator<CreateToDoItemCommand>
    {
        public CreateToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(v => v.Title)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}