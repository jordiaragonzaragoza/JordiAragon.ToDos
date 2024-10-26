namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.MarkAsCompleteToDoItem
{
    using System;
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class MarkAsCompleteToDoItemCommandValidator : AbstractValidator<MarkAsCompleteToDoItemCommand>
    {
        public MarkAsCompleteToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}