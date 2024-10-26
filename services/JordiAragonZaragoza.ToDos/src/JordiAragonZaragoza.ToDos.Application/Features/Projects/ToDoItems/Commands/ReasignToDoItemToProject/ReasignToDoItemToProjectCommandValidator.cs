namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Commands.ReasignToDoItemToProject
{
    using FluentValidation;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Commands;

    public class ReasignToDoItemToProjectCommandValidator : AbstractValidator<ReasignToDoItemToProjectCommand>
    {
        public ReasignToDoItemToProjectCommandValidator()
        {
            this.RuleFor(x => x.ProjectId)
               .NotEmpty().WithMessage("ProjectId is required.");

            this.RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id is required.");

            this.RuleFor(x => x.DestinatioProjectId)
               .NotEmpty().WithMessage("DestinatioProjectId is required.");
        }
    }
}