namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.DeleteToDoItem
{
    using System;
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class DeleteToDoItemCommandValidator : AbstractValidator<DeleteToDoItemCommand>
    {
        public DeleteToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}