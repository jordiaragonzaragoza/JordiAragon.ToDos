namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.MarkAsIncompleteToDoItem
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class MarkAsIncompleteToDoItemCommandValidator : AbstractValidator<MarkAsIncompleteToDoItemCommand>
    {
        public MarkAsIncompleteToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}