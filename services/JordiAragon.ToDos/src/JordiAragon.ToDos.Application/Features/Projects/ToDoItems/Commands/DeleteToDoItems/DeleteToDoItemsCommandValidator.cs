namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.DeleteToDoItems
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class DeleteToDoItemsCommandValidator : AbstractValidator<DeleteToDoItemsCommand>
    {
        public DeleteToDoItemsCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");
        }
    }
}