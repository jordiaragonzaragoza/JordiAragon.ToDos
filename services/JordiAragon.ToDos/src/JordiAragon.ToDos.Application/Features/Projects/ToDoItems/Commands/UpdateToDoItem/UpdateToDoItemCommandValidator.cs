namespace JordiAragon.ToDos.Application.Features.Projects.ToDoItems.Commands.UpdateToDoItem
{
    using System;
    using FluentValidation;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;

    public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
    {
        public UpdateToDoItemCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");
        }
    }
}